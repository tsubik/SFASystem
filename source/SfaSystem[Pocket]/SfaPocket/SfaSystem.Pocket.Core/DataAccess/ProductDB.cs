using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using SFASystem.Pocket.Core.DataAccess;
using System.Data;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.Core.DataAccess
{
    public class ProductDB
    {
        public static IList<Product> GetProducts()
        {
            string sqlQuery = "SELECT * FROM PRODUCT";
            //sqlQuery += " WHERE IsDeleted<>1";
            return GetProductListFromQuery(sqlQuery);
        }

        public static IList<Product> GetProducts(Guid productGroupID, string name)
        {
            string sqlQuery = "SELECT * FROM PRODUCT WHERE Name LIKE '%"+name+"%' AND ProductGroupID IN ";
            IList<ProductGroup> productsGroups = ProductGroupDB.GetAllChildProductsGroup(productGroupID);
            if (productGroupID != Guid.Empty)
                productsGroups.Add(ProductGroupDB.GetProductGroupByID(productGroupID));
            IList<Guid> prodGroupsIds = new List<Guid>();

            StringBuilder INBuilder = new StringBuilder();
            INBuilder.Append("( ");
            for (int i = 0; i < productsGroups.Count; i++)
            {
                INBuilder.Append("'" + productsGroups[i].ProductGroupID + "',");
            }
            INBuilder.Remove(INBuilder.Length - 1, 1);
            INBuilder.Append(") ");
            sqlQuery += INBuilder.ToString();

            return GetProductListFromQuery(sqlQuery);
        }


        public static Product GetProductByID(Guid productID)
        {
            Product product = null;
            if (productID == Guid.Empty)
                return product;

            string sqlQuery = "SELECT * FROM PRODUCT WHERE ProductID='" + productID + "'";
            return GetProductFromQuery(sqlQuery);
        }

        #region Helper Methods

        private static IList<Product> GetProductListFromQuery(string sqlQuery)
        {
            IList<Product> listProduct = new List<Product>();

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    listProduct.Add(GetProductFromReader(dataReader));
                }
            }
            return listProduct;
        }

        private static Product GetProductFromQuery(string sqlQuery)
        {
            Product product = null;

            DbCommand dbCommand = DBHelper.GetDBCommand(sqlQuery);
            using (IDataReader dataReader = DBHelper.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    product = GetProductFromReader(dataReader);
                }
            }
            return product;
        }

        private static Product GetProductFromReader(IDataReader dataReader)
        {
            Product product = new Product();
            product.ProductID = DBHelper.GetGuid(dataReader, "ProductID");
            product.ProductGroupID = DBHelper.GetGuid(dataReader, "ProductGroupID");
            product.ShortDescription = DBHelper.GetString(dataReader, "ShortDescription");
            product.FullDescription = DBHelper.GetString(dataReader, "FullDescription");
            product.Price = DBHelper.GetDecimal(dataReader, "Price");
            product.TaxID = DBHelper.GetGuid(dataReader, "Tax");
            product.Name = DBHelper.GetString(dataReader, "Name");
            product.Code = DBHelper.GetString(dataReader, "Code");
            product.ManufacturerID = DBHelper.GetGuid(dataReader, "ManufacturerID");
            return product;
        }

        #endregion
    }
}
