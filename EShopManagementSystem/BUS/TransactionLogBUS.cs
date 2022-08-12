using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopManagementSystem.DAL;
using EShopManagementSystem.DTO;

namespace EShopManagementSystem.BUS
{
    public class TransactionLogBUS
    {
        public List<TransactionLog> getAllTransactionLogs()
        {
            return new TransactionLogDAL().getAllTransactionLogs();
        }

        public List<TransactionLog> getTransactionLogsByCredentials(string credentials)
        {
            return new TransactionLogDAL().getTransactionLogsByCredentials(credentials);
        }

        public bool addTransactionLog(TransactionLog transaction)
        {
            return new TransactionLogDAL().addTransactionLog(transaction);
        }

        public bool updateTransactionLog(TransactionLog transaction)
        {
            return new TransactionLogDAL().updateTransactionLog(transaction);
        }

        public bool deleteTransactionLog(TransactionLog transaction)
        {
            return new TransactionLogDAL().deleteTransactionLog(transaction);
        }
    }
}