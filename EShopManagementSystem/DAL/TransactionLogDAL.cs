using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class TransactionLogDAL
    {
        public List<TransactionLog> getAllTransactionLogs()
        {
            List<TransactionLog> transactionLogs = new List<TransactionLog>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "SELECT * FROM TransactionLogs;";
            using var cmd = new NpgsqlCommand(sql, connectionString);

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                TransactionLog transaction = new TransactionLog();
                transaction.TransactionId = dataReader.GetString(0);
                transaction.EmployeeId = dataReader.GetString(1);
                transaction.EmployeeName = dataReader.GetString(2);
                transaction.CustomerId = dataReader.GetString(3);
                transaction.CustomerName = dataReader.GetString(4);
                transaction.ProductIds = (List<string>)dataReader.GetValue(5);
                transaction.ProductNames = (List<string>)dataReader.GetValue(6);
                transaction.ProductQuantities = (List<long>)dataReader.GetValue(7);
                transaction.ProductPrices = (List<double>)dataReader.GetValue(8);
                transaction.TransactionDate = dataReader.GetString(9);

                transactionLogs.Add(transaction);
            }

            return transactionLogs;
        }

        public List<TransactionLog> getTransactionLogsByCredentials(string credentials) {
            List<TransactionLog> transactionLogs = new List<TransactionLog>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"SELECT * FROM TransactionLogs WHERE 
            transaction_id LIKE @transaction_id OR 
            employee_id LIKE @employee_id OR 
            employee_name LIKE @employee_name OR 
            customer_id LIKE @customer_id OR 
            customer_name LIKE @customer_name OR 
            transaction_time LIKE @transaction_time;";

            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("transaction_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("employee_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("employee_name", $"%{credentials}%");
            cmd.Parameters.AddWithValue("customer_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("customer_name", $"%{credentials}%");
            cmd.Parameters.AddWithValue("transaction_time", DateTime.Parse(credentials));

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                TransactionLog transaction = new TransactionLog();
                transaction.TransactionId = dataReader.GetString(0);
                transaction.EmployeeId = dataReader.GetString(1);
                transaction.EmployeeName = dataReader.GetString(2);
                transaction.CustomerId = dataReader.GetString(3);
                transaction.CustomerName = dataReader.GetString(4);
                transaction.ProductIds = (List<string>)dataReader.GetValue(5);
                transaction.ProductNames = (List<string>)dataReader.GetValue(6);
                transaction.ProductQuantities = (List<long>)dataReader.GetValue(7);
                transaction.ProductPrices = (List<double>)dataReader.GetValue(8);
                transaction.TransactionDate = dataReader.GetString(9);

                transactionLogs.Add(transaction);
            }

            return transactionLogs;
        }

        public bool addTransactionLog(TransactionLog transaction)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"INSERT INTO TransactionLogs (transaction_id, employ_id, employee_name, customer_id, customer_name, product_ids, product_names, quantities, prices, transaction_time) 
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("transaction_id", transaction.TransactionId);
            cmd.Parameters.AddWithValue("employee_id", transaction.EmployeeId);
            cmd.Parameters.AddWithValue("employee_name", transaction.EmployeeName);
            cmd.Parameters.AddWithValue("customer_id", transaction.CustomerId);
            cmd.Parameters.AddWithValue("customer_name", transaction.CustomerName);
            cmd.Parameters.AddWithValue("product_ids", transaction.ProductIds);
            cmd.Parameters.AddWithValue("product_names", transaction.ProductNames);
            cmd.Parameters.AddWithValue("quantities", transaction.ProductQuantities);
            cmd.Parameters.AddWithValue("prices", transaction.ProductPrices);
            cmd.Parameters.AddWithValue("transaction_time", DateTime.Now);
            cmd.Prepare();

            int addedRows = cmd.ExecuteNonQuery();

            return addedRows > 0;
        }

        public bool updateTransactionLog(TransactionLog transaction) {
            return false;
        }

        public bool deleteTransactionLog(TransactionLog transaction)
        {
            return false;
        }
    }
}