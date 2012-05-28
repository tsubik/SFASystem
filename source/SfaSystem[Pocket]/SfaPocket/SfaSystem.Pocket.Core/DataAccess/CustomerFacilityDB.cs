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
    internal class CustomerFacilityDB
    {
        public static IList<CustomerFacility> GetCustomerFacilities()
        {
            string sqlQuery = "SELECT * FROM CUSTOMERFACILITY";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetCustomerFacilityListFromQuery(sqlQuery);
        }

        public static IList<CustomerFacility> GetCustomerFacilities(Guid customerID, Guid TerritoryID)
        {
            string sqlQuery = "SELECT * FROM CUSTOMERFACILITY";
            bool addedWhere = false;
            bool needAnd = false;
            if (customerID != Guid.Empty)
            {
                sqlQuery += " WHERE CustomerID='" + customerID.ToString() + "' ";
                needAnd = true;
                addedWhere = true;
            }
            if (TerritoryID != Guid.Empty)
            {
                if (!addedWhere)
                {
                    sqlQuery += " WHERE ";
                    addedWhere = true;
                }
                if (needAnd)
                    sqlQuery += " AND ";
                sqlQuery += "TerritoryID='" + TerritoryID.ToString() + "' ";
                needAnd = true;
            }
            //if(!addedWhere)
            //    sqlQuery += " WHERE ";
            //if (needAnd)
            //    sqlQuery += " AND ";
            //sqlQuery += " IsDeleted <> 1";
            return GetCustomerFacilityListFromQuery(sqlQuery);
        }


        public static CustomerFacility GetCustomerFacilityByID(Guid customerFacilityID)
        {
            CustomerFacility customerFacility = null;
            if (customerFacilityID == Guid.Empty)
                return customerFacility;

            string sqlQuery = "SELECT * FROM CUSTOMERFACILITY WHERE CustomerFacilityID='" + customerFacilityID + "'";
            return GetCustomerFacilityFromQuery(sqlQuery);
        }


        #region Helper Methods

        private static IList<CustomerFacility> GetCustomerFacilityListFromQuery(string sqlQuery)
        {
            IList<CustomerFacility> listCustomerFacility = new List<CustomerFacility>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listCustomerFacility.Add(GetCustomerFacilityFromReader(dataReader));
                }
            }
            return listCustomerFacility;
        }

        private static CustomerFacility GetCustomerFacilityFromQuery(string sqlQuery)
        {
            CustomerFacility customerFacility = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    customerFacility = GetCustomerFacilityFromReader(dataReader);
                }
            }
            return customerFacility;
        }

        private static CustomerFacility GetCustomerFacilityFromReader(IDataReader dataReader)
        {
            CustomerFacility customerFacility = new CustomerFacility();
            customerFacility.CustomerFacilityID = DBHelper.GetGuid(dataReader, "CustomerFacilityID");
            customerFacility.AddressID = DBHelper.GetGuid(dataReader, "AddressID");
            customerFacility.TerritoryID = DBHelper.GetGuid(dataReader, "TerritoryID");
            customerFacility.CustomerID = DBHelper.GetGuid(dataReader, "CustomerID");
            customerFacility.Name = DBHelper.GetString(dataReader, "Name");
            customerFacility.Email = DBHelper.GetString(dataReader, "Email");
            customerFacility.Phone = DBHelper.GetString(dataReader, "Phone");
            return customerFacility;
        }

        #endregion

    }
}
