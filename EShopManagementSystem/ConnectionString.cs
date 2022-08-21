using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopManagementSystem
{
    public class ConnectionString
    {
        public static string Get()
        {
            var uriString = ConfigurationManager.AppSettings["DB_URL"] ?? ConfigurationManager.AppSettings["LOCAL_URL"];
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, password, port);
            return connectionString;
        }
    }
}