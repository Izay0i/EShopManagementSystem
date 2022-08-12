using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class EmployeeDAL
    {
        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            return employees;
        }

        public List<Employee> getEmployeesByCredentials(string credentials)
        {
            List<Employee> employees = new List<Employee>();
            return employees;
        }

        public bool addEmployee(Employee employee)
        {
            return false;
        }

        public bool updateEmployee(Employee employee)
        {
            return false;
        }

        public bool deleteEmployee(Employee employee)
        {
            return false;
        }
    }
}