using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.DataAccess;

namespace SFASystem.Pocket.Core.BusinessLogic
{
    public class ProductManager
    {
        private static IList<ProductGroup> productGroupCache = null;
        public static IList<ProductGroup> ProductGroupCache
        {
            get
            {
                if (productGroupCache == null)
                    productGroupCache = ProductGroupDB.GetProductGroups();
                return productGroupCache;
            }
        }

        public static Product GetProductByID(Guid id)
        {
            return ProductDB.GetProductByID(id);
        }

        public static IList<Manufacturer> GetManufacturers()
        {
            return ManufacturerDB.GetManufacturers();
        }

        public static Manufacturer GetManufacturerByID(Guid manID)
        {
            return ManufacturerDB.GetManufacturerByID(manID);
        }

        public static IList<ProductGroup> GetProductGroups()
        {
            return ProductGroupDB.GetProductGroups();
        }

        public static IList<Product> GetProducts(Guid productGroupID, string name)
        {
            IEnumerable<Product> result = ProductDB.GetProducts().Where(p => p.Name.Contains(name));

            if (productGroupID != Guid.Empty)
            {
                ProductGroup productGroup = ProductGroupDB.GetProductGroupByID(productGroupID);
                IList<ProductGroup> allProductsGroups = GetAllChildProductsGroup(productGroupID);
                allProductsGroups.Add(productGroup);

                var productGroupsId = from pG in allProductsGroups
                                      select pG.ProductGroupID;

                result = from p in result
                         where productGroupsId.Contains(p.ProductGroupID)
                         select p;
            }
            return result.ToList();
            //return ProductDB.GetProducts(productGroupID, name);
        }

        public static IList<ProductGroup> GetAllChildProductsGroup(Guid prodGroupID)
        {
            IList<ProductGroup> result = GetSubProductGroups(prodGroupID);
            foreach (ProductGroup prodGr in result)
            {
                IList<ProductGroup> subProd = GetAllChildProductsGroup(prodGr.ProductGroupID);
                result = result.Concat(subProd).ToList();
            }
            return result;
        }


        public static ProductGroup GetProductGroupByID(Guid id)
        {
            return ProductGroupDB.GetProductGroupByID(id);
        }

        public static IList<ProductGroup> GetSubProductGroups(Guid productGroupID)
        {

            return ProductGroupCache.Where(pg => pg.ParentProductGroupID == productGroupID).ToList();

        }

        
      
    }
}
