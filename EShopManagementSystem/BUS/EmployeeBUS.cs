using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DAL;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.BUS
{
    public class EmployeeBUS
    {
        public List<Employee> getAllEmployees()
        {
            return new EmployeeDAL().getAllEmployees();
        }

        public List<Employee> getEmployeesByCredentials(string credentials)
        {
            return new EmployeeDAL().getEmployeesByCredentials(credentials);
        }

        public bool addEmployee(Employee employee)
        {
            return new EmployeeDAL().addEmployee(employee);
        }

        public bool updateEmployee(Employee employee)
        {
            return new EmployeeDAL().updateEmployee(employee);
        }

        public bool deleteEmployee(Employee employee)
        {
            return new EmployeeDAL().deleteEmployee(employee);
        }
    }
}