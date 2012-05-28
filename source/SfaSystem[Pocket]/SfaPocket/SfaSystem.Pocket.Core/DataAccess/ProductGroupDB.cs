using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.DataAccess;
using System.Data.Common;
using SFASystem.Pocket.Core.Common;
using System.Data;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class ProductGroupDB
    {
        public static IList<ProductGroup> GetProductGroups()
        {
            string sqlQuery = "SELECT * FROM ProductGroup";

            //sqlQuery += " WHERE IsDeleted<>1";
            return GetProductGroupListFromQuery(sqlQuery);
        }

        public static ProductGroup GetProductGroupByID(Guid productGroupID)
        {
            ProductGroup productGroup = null;
            if (productGroupID == Guid.Empty)
                return productGroup;

            string sqlQuery = "SELECT * FROM PRODUCTGROUP WHERE ProductGroupID='" + productGroupID + "'";
            return GetProductGroupFromQuery(sqlQuery);
        }

        public static IList<ProductGroup> GetAllChildProductsGroup(Guid prodGroupID)
        {
            string sqlQuery = "With RecursionCTE(ProductGroupID, Pro_ProductGroupID, [Name], Description) " +
                                "as " +
                                "( " +
                                "SELECT ProductGroupID, Pro_ProductGroupID, [Name], Description " +
                                "FROM ProductGroup " +
                                "WHERE Pro_ProductGroupID {0} " +
                                "UNION ALL " +
                                "SELECT p1.ProductGroupID, p1.Pro_ProductGroupID, p1.[Name], p1.Description " +
                                "FROM ProductGroup as p1 " +
                                "JOIN RecursionCTE  as Rec on Rec.ProductGroupID=p1.Pro_ProductGroupID " +
                                ") " +
                                "SELECT * FROM RecursionCTE ";

            string parameter;
            if (prodGroupID != Guid.Empty)
                parameter = "= '" + prodGroupID.ToString() + "'";
            else
                parameter = "IS NULL";

            return GetProductGroupListFromQuery(string.Format(sqlQuery, parameter));
        }


        public static IList<ProductGroup> GetSubProductGroups(Guid productGroupID)
        {
            string sqlQuery = "SELECT * FROM ProductGroup";
            if (productGroupID != Guid.Empty)
                sqlQuery += " Where Pro_ProductGroupID = '" + productGroupID.ToString() + "'";
            else
                sqlQuery += " Where Pro_ProductGroupID IS NULL ";

            return GetProductGroupListFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<ProductGroup> GetProductGroupListFromQuery(string sqlQuery)
        {
            IList<ProductGroup> listProductGroup = new List<ProductGroup>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listProductGroup.Add(GetProductGroupFromReader(dataReader));
                }
            }
            return listProductGroup;
        }

        private static ProductGroup GetProductGroupFromQuery(string sqlQuery)
        {
            ProductGroup productGroup = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    productGroup = GetProductGroupFromReader(dataReader);
                }
            }
            return productGroup;
        }

        private static ProductGroup GetProductGroupFromReader(IDataReader dataReader)
        {
            ProductGroup productGroup = new ProductGroup();
            productGroup.ProductGroupID = DBHelper.GetGuid(dataReader, "ProductGroupID");
            productGroup.ParentProductGroupID = DBHelper.GetGuid(dataReader, "Pro_ProductGroupID");
            productGroup.Name = DBHelper.GetString(dataReader, "Name");
            productGroup.Description = DBHelper.GetString(dataReader, "Description");
            return productGroup;
        }

        #endregion
    }
}
