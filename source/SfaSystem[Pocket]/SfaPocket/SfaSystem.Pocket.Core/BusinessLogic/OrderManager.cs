using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class OrderManager
    {
        public static Order InsertOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.Identifier = GenerateOrderIdentifier(order);
            OrderDB.InsertOrder(order);
            if(order.OrderID!=Guid.Empty)
            {
                foreach (OrderLine line in order.OrderLines)
                {
                    line.OrderID = order.OrderID;
                    OrderLineDB.InsertOrderLine(line);
                }
            }
            return order;
        }

        public static Order GetOrderByID(Guid orderID)
        {
            return OrderDB.GetOrderByID(orderID);
        }

        public static void MarkInvoiceAsPaid(Invoice invoice)
        {
            invoice.IsPaid = true;
            invoice.DatePayment = DateTime.Now;
            invoice.InvoiceStatus = DictionaryManager.GetDictionaryByEnumAndType((int)InvoiceStatusEnum.Zaplacona, DictionaryTypeNames.Invoice);

            InvoiceDB.UpdateInvoice(invoice);
        }

        public static Invoice GetInvoiceByID(Guid invoiceID)
        {
            return InvoiceDB.GetInvoiceByID(invoiceID);
        }

        public static IList<Invoice> GetInvoices()
        {
            return InvoiceDB.GetInvoices();
        }

        public static IList<Invoice> GetInvoices(Customer customer)
        {
            if (customer == null)
                return GetInvoices();
            return InvoiceDB.GetInvoices(customer);
        }
        public static IList<Invoice> GetInvoices(CustomerFacility customerFacility)
        {
            if (customerFacility == null)
                return GetInvoices();
            return InvoiceDB.GetInvoices(customerFacility);
        }

        public static IList<Order> GetOrders()
        {
            return OrderDB.GetOrders();
        }

        public static IList<Order> GetOrders(Customer customer)
        {
            if (customer == null)
                return GetOrders();
            return OrderDB.GetOrders(customer);
        }
        public static IList<Order> GetOrders(CustomerFacility customerFacility)
        {
            if (customerFacility == null)
                return GetOrders();
            return OrderDB.GetOrders(customerFacility);
        }

        private static string GenerateOrderIdentifier(Order order)
        {
            StringBuilder builder = new StringBuilder();
            
            builder.Append(order.OrderDate.Day+"/"+order.OrderDate.Month+"/"+order.OrderDate.Year);
            builder.Append("_" + order.Territory.Name.Substring(0, 2));
            if (order.Employee.Contact != null)
            {
                builder.Append("_" + order.Employee.Contact.FirstName.Substring(0, 1) + order.Employee.Contact.LastName.Substring(0, 1));
            }
            Order newestOrder = OrderDB.GetOrders().Where(o => o.Identifier.Contains(builder.ToString())).OrderByDescending(o => o.Identifier).FirstOrDefault();
            int idx = 1;
            if (newestOrder != null)
            {
                idx = Int32.Parse(newestOrder.Identifier.Replace(builder.ToString() + "_", ""));
                idx++;
            }
            builder.Append("_" + idx);
            return builder.ToString();
        }
    }
}
