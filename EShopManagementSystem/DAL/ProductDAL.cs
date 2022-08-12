using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class ProductDAL
    {
        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            return products;
        }

        public List<Product> getProductByCredentials(string credentials)
        {
            List<Product> products = new List<Product>();
            return products;
        }

        public bool addProduct(Product product)
        {
            return false;
        }

        public bool updateProduct(Product product)
        {
            return false;
        }

        public bool deleteProduct(Product product)
        {
            return false;
        }
    }
}