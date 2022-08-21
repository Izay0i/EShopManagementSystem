using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagementSystem.DTO
{
    public class Product
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Origin { get; set; }
        public String ManufacturedDate { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public long InsuranceDuration { get; set; }
        public float DiscountPercentage { get; set; }

        public Product() {}

        public Product(
            string id, 
            string name, 
            string description, 
            string origin, 
            string manufacturedDate, 
            long quantity, 
            double price, 
            long insuranceDuration, 
            float discountPercentage)
        {
            Id = id;
            Name = name;
            Description = description;
            Origin = origin;
            ManufacturedDate = manufacturedDate;
            Quantity = quantity;
            Price = price;
            InsuranceDuration = insuranceDuration;
            DiscountPercentage = discountPercentage;
        }
    }
}