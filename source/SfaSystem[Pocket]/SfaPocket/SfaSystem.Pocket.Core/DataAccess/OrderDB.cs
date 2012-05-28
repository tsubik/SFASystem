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
    class OrderDB
    {
        public static Order InsertOrder(Order order)
        {
            string sqlQuery = "INSERT INTO [Order] (OrderID, CustomerFacilityID, TerritoryID, EmployeeID, OrderStatus, Identifier, OrderDate, SubTotal, TaxAmount, Total, Comment) " +
                " VALUES(@OrderID,@CustomerFacilityID,@TerritoryID,@EmployeeID,@OrderStatus,@Identifier,@OrderDate,@SubTotal,@TaxAmount,@Total,@Comment)";
            if (order.OrderID == Guid.Empty)
                order.OrderID = Guid.NewGuid();
            else
                return null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "OrderID", DbType.Guid, order.OrderID);
            DBHelper.AddInParameter(dbCommand, "CustomerFacilityID", DbType.Guid, order.CustomerFacilityID);
            DBHelper.AddInParameter(dbCommand, "TerritoryID", DbType.Guid, order.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "EmployeeID", DbType.Guid, order.EmployeeID);
            DBHelper.AddInParameter(dbCommand, "OrderStatus", DbType.Guid, order.OrderStatusID);
            DBHelper.AddInParameter(dbCommand, "Identifier", DbType.String, order.Identifier);
            DBHelper.AddInParameter(dbCommand, "OrderDate", DbType.DateTime, order.OrderDate);
            DBHelper.AddInParameter(dbCommand, "SubTotal", DbType.Decimal, order.SubTotal);
            DBHelper.AddInParameter(dbCommand, "TaxAmount", DbType.Decimal, order.TaxAmount);
            DBHelper.AddInParameter(dbCommand, "Total", DbType.Decimal, order.Total);
            DBHelper.AddInParameter(dbCommand, "Comment", DbType.String, order.Comment);
            DBHelper.ExecuteNonQuery(dbCommand);
            
            return order;
        }

        public static void UpdateOrder(Order order)
        {
            if (order.OrderID == Guid.Empty)
                return;
            string sqlQuery = "UPDATE Order SET CustomerFacilityID=@CustomerFacilityID, TerritoryID=@TerritoryID, EmployeeID=@EmployeeID, OrderStatus=@OrderStatus, Identifier=@Identifier, OrderDate=@OrderDate, DateModified=@DateModified, SubTotal=@SubTotal, TaxAmount=@TaxAmount, Total=@Total, Comment=@Comment  WHERE OrderID='" + order.OrderID + "'";
            
            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "OrderID", DbType.Guid, order.OrderID);
            DBHelper.AddInParameter(dbCommand, "CustomerFacilityID", DbType.Guid, order.CustomerFacilityID);
            DBHelper.AddInParameter(dbCommand, "TerritoryID", DbType.Guid, order.TerritoryID);
            DBHelper.AddInParameter(dbCommand, "EmployeeID", DbType.Guid, order.EmployeeID);
            DBHelper.AddInParameter(dbCommand, "OrderStatus", DbType.Guid, order.OrderStatusID);
            DBHelper.AddInParameter(dbCommand, "Identifier", DbType.String, order.Identifier);
            DBHelper.AddInParameter(dbCommand, "OrderDate", DbType.DateTime, order.OrderDate);
            if (order.DateModified.HasValue)
                DBHelper.AddInParameter(dbCommand, "DateModified", DbType.DateTime, order.DateModified.Value);
            else
                DBHelper.AddInParameter(dbCommand, "DateModified", DbType.DateTime, DBNull.Value);

            DBHelper.AddInParameter(dbCommand, "SubTotal", DbType.Decimal, order.SubTotal);
            DBHelper.AddInParameter(dbCommand, "TaxAmount", DbType.Decimal, order.TaxAmount);
            DBHelper.AddInParameter(dbCommand, "Total", DbType.Decimal, order.Total);
            DBHelper.AddInParameter(dbCommand, "Comment", DbType.String, order.Comment);
            DBHelper.ExecuteNonQuery(dbCommand);
        }

        public static IList<Order> GetOrders(CustomerFacility customerFacility)
        {
            string sqlQuery = "SELECT * FROM [Order] WHERE CustomerFacilityID = '" + customerFacility.CustomerFacilityID + "'";
            return GetOrderListFromQuery(sqlQuery);
        }

        public static IList<Order> GetOrders(Customer customer)
        {
            IList<CustomerFacility> facilities = CustomerFacilityDB.GetCustomerFacilities(customer.CustomerID, Guid.Empty);
            string sqlQuery = "SELECT * FROM [Order] WHERE CustomerFacilityID IN ";
            StringBuilder INBuilder = new StringBuilder();
            INBuilder.Append("( ");
            for (int i = 0; i < facilities.Count; i++)
            {
                INBuilder.Append("'" + facilities[i].CustomerFacilityID + "',");
            }
            INBuilder.Remove(INBuilder.Length - 1, 1);
            INBuilder.Append(") ");
            sqlQuery += INBuilder.ToString();

            return GetOrderListFromQuery(sqlQuery);
        }

        public static IList<Order> GetOrders()
        {
            string sqlQuery = "SELECT * FROM [Order]";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetOrderListFromQuery(sqlQuery);
        }

        public static Order GetOrderByID(Guid orderID)
        {
            Order Order = null;
            if (orderID == Guid.Empty)
                return Order;

            string sqlQuery = "SELECT * FROM [Order] WHERE OrderID='" + orderID + "'";
            return GetOrderFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Order> GetOrderListFromQuery(string sqlQuery)
        {
            IList<Order> listOrder = new List<Order>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listOrder.Add(GetOrderFromReader(dataReader));
                }
            }
            return listOrder;
        }

        private static Order GetOrderFromQuery(string sqlQuery)
        {
            Order Order = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Order = GetOrderFromReader(dataReader);
                }
            }
            return Order;
        }

        private static Order GetOrderFromReader(IDataReader dataReader)
        {
            Order order = new Order();
            order.OrderID = DBHelper.GetGuid(dataReader, "OrderID");
            order.CustomerFacilityID = DBHelper.GetGuid(dataReader, "CustomerFacilityID");
            order.TerritoryID = DBHelper.GetGuid(dataReader, "TerritoryID");
            order.EmployeeID = DBHelper.GetGuid(dataReader, "EmployeeID");
            order.OrderStatusID = DBHelper.GetGuid(dataReader, "OrderStatus");
            order.Identifier = DBHelper.GetString(dataReader, "Identifier");
            order.OrderDate = DBHelper.GetDateTime(dataReader, "OrderDate");
            order.DateModified = DBHelper.GetNullableDateTime(dataReader, "DateModified");
            order.SubTotal = DBHelper.GetDecimal(dataReader, "SubTotal");
            order.TaxAmount = DBHelper.GetDecimal(dataReader, "TaxAmount");
            order.Total = DBHelper.GetDecimal(dataReader, "Total");
            order.Comment = DBHelper.GetString(dataReader, "Comment");
            return order;
        }

        #endregion
    }
}
