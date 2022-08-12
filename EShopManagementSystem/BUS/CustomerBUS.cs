using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DAL;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.BUS
{
    public class CustomerBUS
    {
        public List<Customer> getAllCustomers()
        {
            return new CustomerDAL().getAllCustomers();
        }

        public List<Customer> getCustomersByCredentials(string credentials)
        {
            return new CustomerDAL().getCustomersByCredentials(credentials);
        }

        public bool addCustomer(Customer customer)
        {
            return new CustomerDAL().addCustomer(customer);
        }

        public bool updateCustomer(Customer customer)
        {
            return new CustomerDAL().updateCustomer(customer);
        }

        public bool deleteCustomer(Customer customer)
        {
            return new CustomerDAL().deleteCustomer(customer);
        }
    }
}