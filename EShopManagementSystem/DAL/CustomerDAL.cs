using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class CustomerDAL
    {
        public List<Customer> getAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            return customers;
        }

        public List<Customer> getCustomersByCredentials(String credentials)
        {
            List<Customer> customers = new List<Customer>();
            return customers;
        }

        public bool addCustomer(Customer customer)
        {
            return false;
        } 

        public bool updateCustomer(Customer customer)
        {
            return false;
        }

        public bool deleteCustomer(Customer customer)
        {
            return false;
        }
    }
}