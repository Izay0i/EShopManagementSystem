using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagementSystem.DTO
{
    public class Customer
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }

        public Customer() {}
        public Customer(
            string id, 
            string name, 
            string phoneNumber, 
            string email, 
            string address)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }
    }
}