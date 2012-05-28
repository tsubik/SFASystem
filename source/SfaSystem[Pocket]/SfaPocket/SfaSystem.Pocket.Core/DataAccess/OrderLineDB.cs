using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using System.Data.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    class OrderLineDB
    {
        public static OrderLine InsertOrderLine(OrderLine orderLine)
        {
            string sqlQuery = "INSERT INTO OrderLine(OrderID,ProductID,Quantity,ItemPrice,ItemPriceDiscount,Tax,Total) " +
                " VALUES(@OrderID,@ProductID,@Quantity, @ItemPrice,@ItemPriceDiscount,@Tax, @Total)";
            if (orderLine.OrderID == Guid.Empty)
                return null;
            if (orderLine.ProductID == Guid.Empty)
                return null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "OrderID", DbType.Guid, orderLine.OrderID);
            DBHelper.AddInParameter(dbCommand, "ProductID", DbType.Guid, orderLine.ProductID);
            DBHelper.AddInParameter(dbCommand, "Quantity", DbType.Int32, orderLine.Quantity);
            DBHelper.AddInParameter(dbCommand, "ItemPrice", DbType.Decimal, orderLine.ItemPrice);
            DBHelper.AddInParameter(dbCommand, "ItemPriceDiscount", DbType.Decimal, orderLine.ItemPriceDiscount);
            DBHelper.AddInParameter(dbCommand, "Tax", DbType.Decimal, orderLine.Tax);
            DBHelper.AddInParameter(dbCommand, "Total", DbType.Decimal, orderLine.Total);
            DBHelper.ExecuteNonQuery(dbCommand);
            return orderLine;
        }

        public static void UpdateOrderLine(OrderLine orderLine)
        {
            if (orderLine.OrderID == Guid.Empty)
                return;
            if (orderLine.ProductID == Guid.Empty)
                return;

            string sqlQuery = "UPDATE OrderLine SET Quantity=@Quantity, ItemPrice=@ItemPrice, ItemPriceDiscount=@ItemPriceDiscount,Tax=@Tax, Total=@Total  WHERE OrderID=@OrderID AND ProductID=@ProductID";

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            DBHelper.AddInParameter(dbCommand, "OrderID", DbType.Guid, orderLine.OrderID);
            DBHelper.AddInParameter(dbCommand, "ProductID", DbType.Guid, orderLine.ProductID);
            DBHelper.AddInParameter(dbCommand, "Quantity", DbType.Int32, orderLine.Quantity);
            DBHelper.AddInParameter(dbCommand, "ItemPrice", DbType.Decimal, orderLine.ItemPrice);
            DBHelper.AddInParameter(dbCommand, "ItemPriceDiscount", DbType.Decimal, orderLine.ItemPriceDiscount);
            DBHelper.AddInParameter(dbCommand, "Tax", DbType.Decimal, orderLine.Tax);
            DBHelper.AddInParameter(dbCommand, "Total", DbType.Decimal, orderLine.Total);
            DBHelper.ExecuteNonQuery(dbCommand);
        }


        public static IList<OrderLine> GetOrderLines()
        {
            string sqlQuery = "SELECT * FROM OrderLine";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetOrderLineListFromQuery(sqlQuery);
        }

        public static OrderLine GetOrderLineByID(Guid orderLineID)
        {
            OrderLine orderLine = null;
            if (orderLineID == Guid.Empty)
                return orderLine;

            string sqlQuery = "SELECT * FROM OrderLine WHERE OrderLineID='" + orderLineID + "'";
            return GetOrderLineFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<OrderLine> GetOrderLineListFromQuery(string sqlQuery)
        {
            IList<OrderLine> listOrderLine = new List<OrderLine>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listOrderLine.Add(GetOrderLineFromReader(dataReader));
                }
            }
            return listOrderLine;
        }

        private static OrderLine GetOrderLineFromQuery(string sqlQuery)
        {
            OrderLine orderLine = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    orderLine = GetOrderLineFromReader(dataReader);
                }
            }
            return orderLine;
        }

        private static OrderLine GetOrderLineFromReader(IDataReader dataReader)
        {
            OrderLine orderLine = new OrderLine();
            orderLine.OrderID = DBHelper.GetGuid(dataReader, "OrderID");
            orderLine.ProductID = DBHelper.GetGuid(dataReader, "ProductID");
            orderLine.Quantity = DBHelper.GetInt(dataReader, "Quantity");
            orderLine.ItemPrice = DBHelper.GetDecimal(dataReader, "ItemPrice");
            orderLine.ItemPriceDiscount = DBHelper.GetDecimal(dataReader, "ItemPriceDiscount");
            orderLine.Tax = DBHelper.GetDecimal(dataReader, "Tax");
            orderLine.Total = DBHelper.GetDecimal(dataReader, "Total");
            return orderLine;
        }

        #endregion
    }
}
