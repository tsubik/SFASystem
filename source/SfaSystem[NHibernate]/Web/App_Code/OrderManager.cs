using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFASystem.Domain;
using SFASystem.WebUtils;
using SFASystem.Services;

/// <summary>
/// Summary description for OrderManager
/// </summary>
public class OrderManager
{
    public OrderManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void CancelOrder()
    {
        StateItems.CurrentOrder = null;
        StateItems.IsInOrderMode = false;
    }

    public static void UpdateQuantity(Guid productID, int quantity)
    {
        if (StateItems.IsInOrderMode)
        {
            Order order = StateItems.CurrentOrder;
            OrderLine orderLine = order.OrderLines.Where(o => o.Product.Productid == productID).FirstOrDefault();
            if (orderLine != null)
            {
                Product prod = BasicService<Product, Guid>.GetByID(productID);
                order.TaxAmount -= orderLine.Tax;
                order.Total -= orderLine.Total;
                order.SubTotal = order.Total - order.TaxAmount;

                orderLine.Quantity = quantity;
                int taxValue = Int32.Parse(prod.Tax.Value);
                orderLine.Tax = Math.Round((decimal)((float)orderLine.ItemPrice / (1 + 100.0f / taxValue)) * quantity, 2);
                orderLine.Total = orderLine.Quantity * (orderLine.ItemPrice - orderLine.ItemPriceDiscount);

                
                order.TaxAmount += orderLine.Tax;
                order.Total += orderLine.Total;
                order.SubTotal = order.Total - order.TaxAmount; 
            }
        }
    }

    public static void SetOrderToFacility(CustomerFacility facility)
    {
        if (StateItems.IsInOrderMode)
        {
            Order order = StateItems.CurrentOrder;
            order.CustomerFacility = facility;
            order.Territory = BasicService<Territory, Guid>.GetByID(facility.Territory.Territoryid);
        }
    }

    public static void InsertProductToOrder(Product prod)
    {
        if (StateItems.IsInOrderMode)
        {
            Order order = StateItems.CurrentOrder;
            if (order.OrderLines == null)
                order.OrderLines = new List<OrderLine>();
            int count = order.OrderLines.Where(o => o.Product.Productid == prod.Productid).Count();
            if (count > 0)
                return;

            OrderLine orderLine = new OrderLine();
            orderLine.Id = new OrderLineId(order, prod);
            orderLine.ItemPrice = prod.Price;
            orderLine.ItemPriceDiscount = new decimal(0.0f);
            orderLine.Quantity = 1;
            //orderLine.Product = prod;
            int taxValue = Int32.Parse(prod.Tax.Value);
            orderLine.Tax = Math.Round((decimal)((float)orderLine.ItemPrice / (1 + 100.0f / taxValue)) * 1, 2);
            orderLine.Total = orderLine.Quantity * (orderLine.ItemPrice - orderLine.ItemPriceDiscount);
            order.OrderLines.Add(orderLine);
            
            order.TaxAmount += orderLine.Tax;
            order.Total += orderLine.Total;
            order.SubTotal = (order.Total - order.TaxAmount);
        }
    }
    public static void RemoveProductFromOrder(Product prod)
    {
        if (StateItems.IsInOrderMode)
        {
            Order order = StateItems.CurrentOrder;

            OrderLine line = order.OrderLines.Where(o => o.Product.Productid == prod.Productid).FirstOrDefault();
            if (line != null)
            {
                order.OrderLines.Remove(line);
                order.TaxAmount -= line.Tax;
                order.Total -= line.Total;
                order.SubTotal = order.Total - order.TaxAmount;
            }
        }
    }

    public void AcceptOrder()
    {
        Order order = StateItems.CurrentOrder;

        if (order.CustomerFacility == null)
            throw new SFAException("Wybierz placówkę klienta, przed zatwierdzeniem zamówienia");
        if (order.OrderLines.Count == 0)
            throw new SFAException("Zamówienie musi mieć przynajmniej jedną pozycję");

        order.OrderDate = DateTime.Now;
        order.OrderStatus = SalesService.GetOrderStatusByNumber((int)OrderStatusEnum.Nowe);
        order.Territory = order.CustomerFacility.Territory;
        SalesService.InsertOrder(order);

        StateItems.CurrentOrder = null;
        StateItems.IsInOrderMode = false;
    }
}
