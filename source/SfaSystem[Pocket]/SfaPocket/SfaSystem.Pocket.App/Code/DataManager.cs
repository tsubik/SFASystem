using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.App.Code
{
    public class DataManager : Singleton<DataManager>
    {
        private Guid currentEmployeeID;
        public Guid CurrentEmployeeID
        {
            get
            {
                return currentEmployeeID;
            }
            set
            {
                currentEmployeeID = value;
            }
        }

        private Order currentOrder;

        public Order CurrentOrder
        {
            get
            {
                if (currentOrder == null)
                    currentOrder = new Order();
                return currentOrder;
            }
            set
            {
                currentOrder = value;
            }
        }

        private IList<ProductGroup> productGroups = null;
        public IList<ProductGroup> ProductGroups
        {
            get
            {
                if (productGroups == null)
                    productGroups = ProductManager.GetProductGroups();
                return productGroups;
            }
        }

        public void InsertProductToOrder(Guid productID)
        {
            Product prod = ProductManager.GetProductByID(productID);
            if (CurrentOrder.OrderLines == null)
                CurrentOrder.OrderLines = new List<OrderLine>();
            int count = CurrentOrder.OrderLines.Where(o => o.ProductID == prod.ProductID).Count();
            if (count > 0)
                return;
            
            OrderLine orderLine = new OrderLine();
            orderLine.ProductID = prod.ProductID;
            orderLine.ItemPrice = prod.Price;
            orderLine.ItemPriceDiscount = new decimal(0.0f);
            orderLine.Quantity = 1;
            int taxValue = Int32.Parse(prod.Tax.Value);
            orderLine.Tax = (decimal)((float)orderLine.ItemPrice / (1 + 100.0f / taxValue)) * 1;
            orderLine.Total = orderLine.Quantity * (orderLine.ItemPrice - orderLine.ItemPriceDiscount);
            CurrentOrder.OrderLines.Add(orderLine);
            CurrentOrder.SubTotal += orderLine.Total;
            CurrentOrder.TaxAmount += orderLine.Total * (decimal) (22 / 100);
            CurrentOrder.Total = CurrentOrder.SubTotal + CurrentOrder.TaxAmount;
        }

        public void RemoveProductFromOrder(Guid productID)
        {
            OrderLine line = CurrentOrder.OrderLines.First(o => o.ProductID == productID);
            CurrentOrder.OrderLines.Remove(line);
            CurrentOrder.SubTotal -= line.Total;
            CurrentOrder.TaxAmount -= line.Total * (decimal)(22 / 100);
            CurrentOrder.Total = CurrentOrder.SubTotal + CurrentOrder.TaxAmount;
        }

        public void AcceptOrder()
        {
            if (CurrentOrder.CustomerFacilityID == Guid.Empty)
                throw new SFAException("Wybierz placówkę klienta, przed zatwierdzeniem zamówienia");
            if (CurrentOrder.OrderLines.Count == 0)
                throw new SFAException("Zamówienie musi mieć przynajmniej jedną pozycję");

            CurrentOrder.OrderDate = DateTime.Now;
            CurrentOrder.OrderStatusID = DictionaryManager.GetDictionaryByEnumAndType((int)OrderStatusEnum.Nowe, DictionaryTypeNames.Order).DictionaryID;
            CurrentOrder.Identifier = "Nie uzupełniono";
            CurrentOrder.EmployeeID = ApplicationManager.Instance.CurrentEmployee.EmployeeID;
            CurrentOrder.TerritoryID = CustomerManager.GetCustomerFacilityByID(CurrentOrder.CustomerFacilityID).TerritoryID;

            OrderManager.InsertOrder(CurrentOrder);
            CurrentOrder = null;
        }
    }
}
