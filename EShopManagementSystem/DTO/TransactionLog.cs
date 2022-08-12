using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagementSystem.DTO
{
    public class TransactionLog
    {
        public string TransactionId { get; set; }
        public string EmployeeId { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public List<string> ProductIds { get; set; }
        public List<string> ProductNames { get; set; }
        public List<long> ProductQuantities { get; set; }
        public List<double> ProductPrices { get; set; }
        public string TransactionDate { get; set; }
        public string ReprintedDate { get; set; }

        public TransactionLog() {}

        public TransactionLog(string transactionId, string employeeId, string customerId, string employeeName, string customerName, List<string> productIds, List<string> productNames, List<long> productQuantities, List<double> productPrices, string transactionDate, string reprintedDate)
        {
            TransactionId = transactionId;
            EmployeeId = employeeId;
            CustomerId = customerId;
            EmployeeName = employeeName;
            CustomerName = customerName;
            ProductIds = productIds;
            ProductNames = productNames;
            ProductQuantities = productQuantities;
            ProductPrices = productPrices;
            TransactionDate = transactionDate;
            ReprintedDate = reprintedDate;
        }
    }
}