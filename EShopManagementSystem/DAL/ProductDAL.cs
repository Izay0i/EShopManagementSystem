using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class ProductDAL
    {
        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "SELECT * FROM Products;";
            using var cmd = new NpgsqlCommand(sql, connectionString);

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.Id = dataReader.GetString(0);
                product.Name = dataReader.GetString(1);
                product.Description = dataReader.GetString(2);
                product.Origin = dataReader.GetString(3);
                product.ManufacturedDate = dataReader.GetString(4);
                product.Quantity = dataReader.GetInt64(5);
                product.Price = dataReader.GetDouble(6);
                product.InsuranceDuration = dataReader.GetInt64(7);
                product.DiscountPercentage = dataReader.GetFloat(8);

                products.Add(product);
            }

            return products;
        }

        public List<Product> getProductByCredentials(string credentials)
        {
            List<Product> products = new List<Product>();

            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"SELECT * FROM Products WHERE 
            product_id LIKE @product_id OR 
            name LIKE @name OR 
            description LIKE @description OR 
            origin LIKE @origin OR 
            manufacture_date LIKE @manufacture_date OR 
            quantity LIKE @quantity OR 
            price LIKE @price OR 
            insurance_duration LIKE @insurance_duration OR 
            discount_percentage LIKE @discount_percentage;";

            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("product_id", $"%{credentials}%");
            cmd.Parameters.AddWithValue("name", $"%{credentials}%");
            cmd.Parameters.AddWithValue("description", $"%{credentials}%");
            cmd.Parameters.AddWithValue("origin", $"%{credentials}%");
            cmd.Parameters.AddWithValue("manufacture_date", $"%{credentials}%");
            cmd.Parameters.AddWithValue("quantity", $"%{credentials}%");
            cmd.Parameters.AddWithValue("price", $"%{credentials}%");
            cmd.Parameters.AddWithValue("insurance_duration", $"%{credentials}%");
            cmd.Parameters.AddWithValue("discount_percentage", $"%{credentials}%");

            using NpgsqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.Id = dataReader.GetString(0);
                product.Name = dataReader.GetString(1);
                product.Description = dataReader.GetString(2);
                product.Origin = dataReader.GetString(3);
                product.ManufacturedDate = dataReader.GetString(4);
                product.Quantity = dataReader.GetInt64(5);
                product.Price = dataReader.GetDouble(6);
                product.InsuranceDuration = dataReader.GetInt64(7);
                product.DiscountPercentage = dataReader.GetFloat(8);

                products.Add(product);
            }

            return products;
        }

        public bool addProduct(Product product)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"INSERT INTO Products (product_id, name, description, origin, manufacture_date, quantity, price, insurance_duration, discount_percentage) 
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);";
            
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("product_id", product.Id);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("description", product.Description);
            cmd.Parameters.AddWithValue("origin", product.Origin);
            cmd.Parameters.AddWithValue("manufacture_date", DateTime.Parse(product.ManufacturedDate));
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("price", product.Price);
            cmd.Parameters.AddWithValue("insurance_duration", product.InsuranceDuration);
            cmd.Parameters.AddWithValue("discount_percentage", product.DiscountPercentage);
            cmd.Prepare();

            int addedRows = cmd.ExecuteNonQuery();

            return addedRows > 0;
        }

        public bool updateProduct(Product product)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = @"UPDATE Products SET (name, description, origin, manufacture_date, quantity, price, insurance_duration, discount_percentage) 
            = (?, ?, ?, ?, ?, ?, ?, ?) 
            WHERE product_id = ?;";

            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("description", product.Description);
            cmd.Parameters.AddWithValue("origin", product.Origin);
            cmd.Parameters.AddWithValue("manufacture_date", DateTime.Parse(product.ManufacturedDate));
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("price", product.Price);
            cmd.Parameters.AddWithValue("insurance_duration", product.InsuranceDuration);
            cmd.Parameters.AddWithValue("discount_percentage", product.DiscountPercentage);
            cmd.Parameters.AddWithValue("product_id", product.Id);
            cmd.Prepare();

            int updatedRows = cmd.ExecuteNonQuery();

            return updatedRows > 0;
        }

        public bool deleteProduct(Product product)
        {
            using var connectionString = new NpgsqlConnection(ConnectionString.Get());
            connectionString.Open();

            var sql = "DELETE FROM Products WHERE product_id = ?;";
            using var cmd = new NpgsqlCommand(sql, connectionString);
            cmd.Parameters.AddWithValue("product_id", product.Id);
            cmd.Prepare();

            int deletedRows = cmd.ExecuteNonQuery();

            return deletedRows > 0;
        }
    }
}