using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.DataAccess.SqlServerNH;
using SFASystem.Domain;

namespace SFASystem.Services
{
    public class SalesService
    {
        private static SalesRepository salesRepository;

        static SalesService()
        {
            salesRepository = new SalesRepository();
        }

        public static IList<Territory> GetSubTerritories(Territory parent)
        {
            return salesRepository.GetSubTerritories(parent);
        }

        public static Order InsertOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.Identifier = GenerateOrderIdentifier(order);
            order.OrderStatus = GetOrderStatusByNumber((int)OrderStatusEnum.Nowe);
            BasicService<Order, Guid>.SaveOrUpdate(order);
            foreach (OrderLine line in order.OrderLines)
            {
                BasicService<OrderLine, Guid>.SaveOrUpdate(line);
            }
            return order;
        }

        public static IList<Order> GetOrders()
        {
            return BasicService<Order, Guid>.GetAll();
        }

        public static IList<Order> GetOrders(CustomerFacility fac)
        {
            Repository<Order, Guid> rep = new Repository<Order, Guid>();
            var result = from o in rep.GetQueryable() select o;
            if (fac != null)
                result = result.Where(o => o.CustomerFacility == fac);
            return result.ToList();
        }

        public static IList<Order> GetOrders(Customer customer, Employee emp, Territory terr,
            DateTime? startDate, DateTime? endDate, Dictionary orderStatus)
        {
            Repository<Order, Guid> rep = new Repository<Order, Guid>();
            var result = from o in rep.GetQueryable() select o;
            if (customer != null)
                result = result.Where(o => o.CustomerFacility.Customer == customer);
            if (emp != null)
                result = result.Where(o => o.Employee == emp);
            if (terr != null)
                result = result.Where(o => o.Territory == terr);
            if (orderStatus != null)
                result = result.Where(o => o.OrderStatus == orderStatus);
            if (startDate.HasValue)
                result = result.Where(o => o.OrderDate > startDate.Value);
            if (endDate.HasValue)
                result = result.Where(o => o.OrderDate < endDate.Value);

            return result.ToList();
        }

        public static IList<Invoice> GetInvoices(Dictionary status)
        {
            Repository<Invoice, Guid> rep = new Repository<Invoice, Guid>();
            var result = from i in rep.GetQueryable() select i;
            if (status != null)
                result = result.Where(i => i.InvoiceStatus == status);

            return result.ToList();
        }

        public static bool HasOrderInvoice(Order order)
        {
            Repository<Invoice, Guid> rep = new Repository<Invoice, Guid>();
            var result = from i in rep.GetQueryable() where i.Order == order select i;
            if (result.Count() > 0)
                return true;
            else
                return false;
        }

        public static void CreateInvoice(Order order)
        {
            Invoice invoice = new Invoice();
            invoice.Number = GenerateInvoiceNumber();
            invoice.Date = DateTime.Now;
            invoice.InvoiceStatus = SalesService.GetInvoiceStatusByNumber((int)InvoiceStatusEnum.Niezaplacona);
            invoice.IsPaid = false;
            invoice.Order = order;
            BasicService<Invoice, Guid>.SaveOrUpdate(invoice);
        }

        public static void MarkInvoiceAsPaid(Guid invoiceID)
        {
            Invoice invoice = BasicService<Invoice, Guid>.GetByID(invoiceID);
            invoice.IsPaid = true;
            invoice.DatePayment = DateTime.Now;
            invoice.InvoiceStatus = SalesService.GetInvoiceStatusByNumber((int)InvoiceStatusEnum.Zaplacona);
            BasicService<Invoice, Guid>.SaveOrUpdate(invoice);
        }

        public static void ApproveOrder(Order order)
        {
            if (order != null)
            {
                if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.Nowe)
                {
                    order.OrderStatus = SalesService.GetOrderStatusByNumber((int)OrderStatusEnum.WRealizacji);
                    BasicService<Order, Guid>.SaveOrUpdate(order);
                }
            }
        }

        private static string GenerateInvoiceNumber()
        {
            string result = string.Empty;
            Repository<Invoice, Guid> rep = new Repository<Invoice, Guid>();
            string year = DateTime.Now.Year.ToString();
            var invoices = from i in rep.GetQueryable() where i.Number.Contains(year) orderby i.Number descending select i;
            Invoice inv = invoices.FirstOrDefault();
            if (inv != null)
            {

                string number = inv.Number.Split(' ')[1];
                int invNr = number.IndexOf("/");
                int nr = Int32.Parse(number.Substring(0, invNr));
                nr++;

                return "FV " + nr + "/" + year;
            }
            else
                return "FV 1/" + year;
        }

        public static void CancelOrder(Order order)
        {
            if (order != null)
            {
                order.OrderStatus = SalesService.GetOrderStatusByNumber((int)OrderStatusEnum.Anulowane);
                BasicService<Order, Guid>.SaveOrUpdate(order);
                if (HasOrderInvoice(order))
                {
                    Invoice invoice = GetInvoices(null).Where(i => i.Order == order).SingleOrDefault();
                    if (invoice != null)
                        BasicService<Invoice, Guid>.Delete(invoice);
                }
            }
        }
        public static void SetOrderAsShipped(Order order)
        {
            if (order != null)
            {
                if (order.OrderStatus.DictionaryNumber == (int)OrderStatusEnum.WRealizacji)
                {
                    order.OrderStatus = SalesService.GetOrderStatusByNumber((int)OrderStatusEnum.Wyslano);
                    BasicService<Order, Guid>.SaveOrUpdate(order);
                }
            }
        }

        public static Dictionary GetOrderStatusByNumber(int number)
        {
            Repository<Dictionary, Guid> rep = new Repository<Dictionary, Guid>();
            var result = from dict in rep.GetQueryable()
                         where dict.DictionaryType.Name == DictionaryTypeNames.Order && dict.DictionaryNumber == number
                         select dict;
            return result.SingleOrDefault();
        }
        public static Dictionary GetInvoiceStatusByNumber(int number)
        {
            Repository<Dictionary, Guid> rep = new Repository<Dictionary, Guid>();
            var result = from dict in rep.GetQueryable()
                         where dict.DictionaryType.Name == DictionaryTypeNames.Invoice && dict.DictionaryNumber == number
                         select dict;
            return result.SingleOrDefault();
        }

        private static string GenerateOrderIdentifier(Order order)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(order.OrderDate.Day + "/" + order.OrderDate.Month + "/" + order.OrderDate.Year);
            builder.Append("_" + order.Territory.Name.Substring(0, 2));
            if (order.Employee.Contact != null)
            {
                builder.Append("_" + order.Employee.Contact.FirstName.Substring(0, 1) + order.Employee.Contact.LastName.Substring(0, 1));
            }
            Repository<Order, Guid> repOrder = new Repository<Order,Guid>();
            Order newestOrder = repOrder.GetQueryable().Where(o => o.Identifier.Contains(builder.ToString())).OrderByDescending(o => o.Identifier).FirstOrDefault();
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
