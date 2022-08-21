using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class EmployeeDAL
    {
        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "SELECT * FROM Employees;";
            using var cmd = new NpgsqlCommand(sql, connectionString);

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = dataReader.GetString(0);
                employee.Name = dataReader.GetString(1);
                employee.Email = dataReader.GetString(2);
                employee.Birthdate = dataReader.GetString(4);
                employee.Gender = dataReader.GetString(5);

                employees.Add(employee);
            }

            return employees;
        }

        public List<Employee> getEmployeesByCredentials(string credentials)
        {
            List<Employee> employees = new List<Employee>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"SELECT * FROM Employees WHERE 
            employ_id LIKE @employ_id OR 
            full_name LIKE @full_name OR 
            email LIKE @email OR 
            birth_date LIKE @birth_date OR 
            gender LIKE @gender;";
            
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("employ_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("full_name", $"%{credentials}%");
            cmd.Parameters.AddWithValue("email", $"%{credentials}%");
            cmd.Parameters.AddWithValue("birth_date", DateTime.Parse(credentials));
            cmd.Parameters.AddWithValue("gender", $"%{credentials}%");

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = dataReader.GetString(0);
                employee.Name = dataReader.GetString(1);
                employee.Email = dataReader.GetString(2);
                employee.Birthdate = dataReader.GetString(4);
                employee.Gender = dataReader.GetString(5);

                employees.Add(employee);
            }

            return employees;
        }

        public bool addEmployee(Employee employee)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "INSERT INTO Employees (employ_id, full_name, email, birth_date, gender) VALUES (?, ?, ?, ?, ?);";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("employ_id", employee.Id);
            cmd.Parameters.AddWithValue("full_name", employee.Name);
            cmd.Parameters.AddWithValue("email", employee.Email);
            cmd.Parameters.AddWithValue("birth_date", DateTime.Parse(employee.Birthdate));
            cmd.Parameters.AddWithValue("gender", employee.Gender);
            cmd.Prepare();

            int addedRows = cmd.ExecuteNonQuery();

            return addedRows > 0;
        }

        public bool updateEmployee(Employee employee)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "UPDATE Employees SET (full_name, email, birth_date, gender) = (?, ?, ?, ?) WHERE employ_id = ?;";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("full_name", employee.Name);
            cmd.Parameters.AddWithValue("email", employee.Email);
            cmd.Parameters.AddWithValue("birth_date", DateTime.Parse(employee.Birthdate));
            cmd.Parameters.AddWithValue("gender", employee.Gender);
            cmd.Parameters.AddWithValue("employ_id", employee.Id);
            cmd.Prepare();

            int updatedRows = cmd.ExecuteNonQuery();

            return updatedRows > 0;
        }

        public bool deleteEmployee(Employee employee)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "DELETE FROM Employees WHERE employ_id = ?;";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("employ_id", employee.Id);
            cmd.Prepare();

            int deletedRows = cmd.ExecuteNonQuery();

            return deletedRows > 0;
        }
    }
}