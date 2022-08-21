using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class CustomerDAL
    {
        public List<Customer> getAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "SELECT * FROM Customers;";
            using var cmd = new NpgsqlCommand(sql, connectionString);

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = dataReader.GetString(0);
                customer.Name = dataReader.GetString(1);
                customer.PhoneNumber = dataReader.GetString(2);
                customer.Email = dataReader.GetString(3);
                customer.Address = dataReader.GetString(4);

                customers.Add(customer);
            }

            return customers;
        }

        public List<Customer> getCustomersByCredentials(string credentials)
        {
            List<Customer> customers = new List<Customer>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"SELECT * FROM Customers WHERE 
            customer_id LIKE @customer_id OR 
            full_name LIKE @full_name OR 
            phone LIKE @phone OR 
            email LIKE @email OR 
            address LIKE @address;";
            
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("customer_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("full_name", $"%{credentials}%");
            cmd.Parameters.AddWithValue("phone", $"%{credentials}%");
            cmd.Parameters.AddWithValue("email", $"%{credentials}%");
            cmd.Parameters.AddWithValue("address", $"%{credentials}%");

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = dataReader.GetString(0);
                customer.Name = dataReader.GetString(1);
                customer.PhoneNumber = dataReader.GetString(2);
                customer.Email = dataReader.GetString(3);
                customer.Address = dataReader.GetString(4);

                customers.Add(customer);
            }

            return customers;
        }

        public bool addCustomer(Customer customer)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "INSERT INTO Customers (customer_id, full_name, phone, email, address) VALUES (?, ?, ?, ?, ?);";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("customer_id", customer.Id);
            cmd.Parameters.AddWithValue("full_name", customer.Name);
            cmd.Parameters.AddWithValue("phone", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("email", customer.Email);
            cmd.Parameters.AddWithValue("address", customer.Address);
            cmd.Prepare();

            int addedRows = cmd.ExecuteNonQuery();

            return addedRows > 0;
        } 

        public bool updateCustomer(Customer customer)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "UPDATE Customers SET (full_name, phone, email, address) = (?, ?, ?, ?) WHERE customer_id = ?;";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("full_name", customer.Name);
            cmd.Parameters.AddWithValue("phone", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("email", customer.Email);
            cmd.Parameters.AddWithValue("address", customer.Address);
            cmd.Parameters.AddWithValue("customer_id", customer.Id);
            cmd.Prepare();

            int updatedRows = cmd.ExecuteNonQuery();

            return updatedRows > 0;
        }

        public bool deleteCustomer(Customer customer)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "DELETE FROM Customers WHERE customer_id = ?;";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("customer_id", customer.Id);
            cmd.Prepare();

            int deletedRows = cmd.ExecuteNonQuery();

            return deletedRows > 0;
        }
    }
}