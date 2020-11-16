using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public static class Db
    {
        static string connectionString;

        /// <summary>
        /// Get method for the connection string to the database
        /// </summary>
        static public string ConnectionString
        {
            get
            {
                return connectionString ??
                       (connectionString = @"Data Source=|DataDirectory|\BookStore.sqlite");
            }
        }
    }
}
