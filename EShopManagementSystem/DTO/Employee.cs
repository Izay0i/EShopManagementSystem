using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagementSystem.DTO
{
    public class Employee
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Birthdate { get; set; }
        public String Gender { get; set; }

        public Employee() {}

        public Employee(
            string id, 
            string name, 
            string email, 
            string birthdate, 
            string gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            Gender = gender;
        }
    }
}