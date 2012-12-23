using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFASystem.Domain;
using SFASystem.DataAccess.SqlServerNH;

namespace SFASystem.Services
{
    public class CatalogService
    {
        private static ProductRepository productRepository;

        static CatalogService()
        {
            productRepository = new ProductRepository();
        }

        public static IList<ProductGroup> GetProductGroups()
        {
            return BasicService<ProductGroup, Guid>.GetAll();
        }

        public static IList<ProductGroup> GetSubProductsGroups(ProductGroup parent)
        {
            //if (prodGroupId == Guid.Empty)
            //    return null;
            return productRepository.GetSubProductsGroups(parent);
        }

        public static Product GetProductByID(Guid prodId)
        {
            return productRepository.GetByID(prodId);
        }

        public static IList<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public static IList<ProductGroup> GetAllChildProductsGroup(ProductGroup prodGroup)
        {
            IList<ProductGroup> result = GetSubProductsGroups(prodGroup);
            foreach (ProductGroup prodGr in result)
            {
                IList<ProductGroup> subProd = GetAllChildProductsGroup(prodGr);
                result = result.Concat(subProd).ToList();
            }
            return result;
        }

        public static IList<Product> GetProducts(string productCode, string productName, ProductGroup productGroup, Manufacturer manufacturer)
        {
            var result = productRepository.GetQueryable().Where(p => p.Name.Contains(productName)
                && p.Code.Contains(productCode)).AsEnumerable();
            if (manufacturer != null)
            {
                result = from p in result
                         where p.Manufacturer == manufacturer
                         select p;
            }

            if (productGroup != null)
            {
                IList<ProductGroup> allProductsGroups = GetAllChildProductsGroup(productGroup);
                allProductsGroups.Add(productGroup);
                var productGroupsId = from pG in allProductsGroups
                                      select pG.ProductGroupID;

                result = from p in result
                         where productGroupsId.Contains(p.ProductGroup.ProductGroupID)
                         select p;
            }
            return result.ToList();    
        }

        public static void MarkProductAsDeleted(Guid productID)
        {
            Product product = productRepository.GetByID(productID);
            product.IsDeleted = true;
            productRepository.SaveOrUpdate(product);
        }
        public static void MarkProductGroupAsDeleted(Guid productGroupID)
        {
            ProductGroup productGroup = BasicService<ProductGroup, Guid>.GetByID(productGroupID);
            productGroup.IsDeleted = true;
            BasicService<ProductGroup, Guid>.SaveOrUpdate(productGroup);
        }


    }
}
