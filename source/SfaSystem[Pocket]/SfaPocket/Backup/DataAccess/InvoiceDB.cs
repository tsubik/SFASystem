using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using SFASystem.Pocket.Core.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{

    class InvoiceDB
    {
        public static void UpdateInvoice(Invoice invoice)
        {
            if (invoice.Invoiceid == Guid.Empty)
                return;
            string sqlQuery = "UPDATE Invoice SET DatePayment=@DatePayment, IsPaid=@IsPaid, InvoiceStatus=@InvoiceStatus WHERE InvoiceID='" + invoice.Invoiceid + "'";

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            if(invoice.DatePayment.HasValue)
                DBHelper.AddInParameter(dbCommand, "DatePayment", DbType.DateTime, invoice.DatePayment.Value);
            else
                DBHelper.AddInParameter(dbCommand, "DatePayment", DbType.DateTime,DBNull.Value);
            DBHelper.AddInParameter(dbCommand, "IsPaid", DbType.Boolean, invoice.IsPaid);
            DBHelper.AddInParameter(dbCommand, "InvoiceStatus", DbType.Guid, invoice.InvoiceStatusID);
            DBHelper.ExecuteNonQuery(dbCommand);
        }

        public static IList<Invoice> GetInvoices(CustomerFacility customerFacility)
        {
            string sqlQuery = "SELECT * FROM Invoice inv Join [Order] ord on inv.OrderID=ord.OrderID WHERE ord.CustomerFacilityID = '" + customerFacility.CustomerFacilityID + "'";
            return GetInvoiceListFromQuery(sqlQuery);
        }

        public static IList<Invoice> GetInvoices(Customer customer)
        {
            IList<CustomerFacility> facilities = CustomerFacilityDB.GetCustomerFacilities(customer.CustomerID, Guid.Empty);
            string sqlQuery = "SELECT * FROM Invoice inv Join [Order] ord on inv.OrderID=ord.OrderID WHERE ord.CustomerFacilityID IN ";
            StringBuilder INBuilder = new StringBuilder();
            INBuilder.Append("( ");
            for (int i = 0; i < facilities.Count; i++)
            {
                INBuilder.Append("'" + facilities[i].CustomerFacilityID + "',");
            }
            INBuilder.Remove(INBuilder.Length - 1, 1);
            INBuilder.Append(") ");
            sqlQuery += INBuilder.ToString();

            return GetInvoiceListFromQuery(sqlQuery);
        }

        public static IList<Invoice> GetInvoices()
        {
            string sqlQuery = "SELECT * FROM Invoice";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetInvoiceListFromQuery(sqlQuery);
        }

        public static Invoice GetInvoiceByID(Guid invoiceID)
        {
            Invoice Invoice = null;
            if (invoiceID == Guid.Empty)
                return Invoice;

            string sqlQuery = "SELECT * FROM Invoice WHERE InvoiceID='" + invoiceID + "'";
            return GetInvoiceFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Invoice> GetInvoiceListFromQuery(string sqlQuery)
        {
            IList<Invoice> listInvoice = new List<Invoice>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listInvoice.Add(GetInvoiceFromReader(dataReader));
                }
            }
            return listInvoice;
        }

        private static Invoice GetInvoiceFromQuery(string sqlQuery)
        {
            Invoice Invoice = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Invoice = GetInvoiceFromReader(dataReader);
                }
            }
            return Invoice;
        }

        private static Invoice GetInvoiceFromReader(IDataReader dataReader)
        {
            Invoice invoice = new Invoice();
            invoice.Invoiceid = DBHelper.GetGuid(dataReader, "InvoiceID");
            invoice.OrderID = DBHelper.GetGuid(dataReader, "OrderID");
            invoice.InvoiceStatusID = DBHelper.GetGuid(dataReader, "InvoiceStatus");
            invoice.Number = DBHelper.GetString(dataReader, "Number");
            invoice.Date = DBHelper.GetDateTime(dataReader, "Date");
            invoice.DatePayment = DBHelper.GetNullableDateTime(dataReader, "DatePayment");
            invoice.IsPaid = DBHelper.GetBoolean(dataReader, "IsPaid");
            
            return invoice;
        }

        #endregion
    }

}
