using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DTO;

namespace EShopManagementSystem.DAL
{
    public class TransactionLogDAL
    {
        public List<TransactionLog> getAllTransactionLogs()
        {
            List<TransactionLog> transactionLogs = new List<TransactionLog>();
            return transactionLogs;
        }

        public List<TransactionLog> getTransactionLogsByCredentials(string credentials) {
            List<TransactionLog> transactionLogs = new List<TransactionLog>();
            return transactionLogs;
        }

        public bool addTransactionLog(TransactionLog transaction)
        {
            return false;
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