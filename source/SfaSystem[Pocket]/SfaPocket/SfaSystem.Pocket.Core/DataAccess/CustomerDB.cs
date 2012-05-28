using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using System.Data;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.DataAccess
{
    internal class CustomerDB
    {
        public static IList<Customer> GetCustomers()
        {
            string sqlQuery = "SELECT * FROM CUSTOMER";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetCustomerListFromQuery(sqlQuery);
        }

        public static Customer GetCustomerByID(Guid customerID)
        {
            Customer customer = null;
            if (customerID == Guid.Empty)
                return customer;

            string sqlQuery = "SELECT * FROM CUSTOMER WHERE CustomerID='" + customerID + "'";
            return GetCustomerFromQuery(sqlQuery);
        }

        


        #region Helper Methods

        private static IList<Customer> GetCustomerListFromQuery(string sqlQuery)
        {
            IList<Customer> listCustomer = new List<Customer>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listCustomer.Add(GetCustomerFromReader(dataReader));
                }
            }
            return listCustomer;
        }

        private static Customer GetCustomerFromQuery(string sqlQuery)
        {
            Customer customer = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    customer = GetCustomerFromReader(dataReader);
                }
            }
            return customer;
        }

        private static Customer GetCustomerFromReader(IDataReader dataReader)
        {
            Customer customer = new Customer();
            customer.CustomerID = DBHelper.GetGuid(dataReader, "CustomerID");
            customer.ContactID = DBHelper.GetGuid(dataReader, "ContactID");
            customer.FullDescription = DBHelper.GetString(dataReader, "FullDescription");
            customer.CustomerSince = DBHelper.GetNullableDateTime(dataReader, "CustomerSince");
            customer.CustomerTo = DBHelper.GetNullableDateTime(dataReader, "CustomerTo");
            customer.Code = DBHelper.GetString(dataReader, "Code");
            customer.Name = DBHelper.GetString(dataReader, "Name");
            customer.NIP = DBHelper.GetString(dataReader, "NIP");
            customer.KRS = DBHelper.GetString(dataReader, "KRS");
            customer.REGON = DBHelper.GetString(dataReader, "REGON");
            customer.Email = DBHelper.GetString(dataReader, "Email");
            customer.Phone = DBHelper.GetString(dataReader, "Phone");
            return customer;
        }

        #endregion
    }
}
