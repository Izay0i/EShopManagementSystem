using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DAL;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.BUS
{
    public class ProductBUS
    {
        public List<Product> getAllProducts()
        {
            return new ProductDAL().getAllProducts();
        }

        public List<Product> getProductsByCredentials(string credentials)
        {
            return new ProductDAL().getProductByCredentials(credentials);
        }

        public bool addProduct(Product product)
        {
            return new ProductDAL().addProduct(product);
        }

        public bool updateProduct(Product product)
        {
            return new ProductDAL().updateProduct(product);
        }

        public bool deleteProduct(Product product)
        {
            return new ProductDAL().deleteProduct(product);
        }
    }
}