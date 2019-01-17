using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace LogicLayer
{ 
    internal class DBManager
    {
        private const string DB_CATALOG = "DellOrtoLuraschi";
        private const string DB_USER = "dellorto";
        private const string DB_PASSWORD = "passw0rd";

        internal static SqlConnection getConnection()
        {
            string connectionString = String.Format(
            "Data Source=(local);;Connection Timeout=3;Initial Catalog={0};"
            + "User Id={1};Password={2};", DB_CATALOG, DB_USER, DB_PASSWORD);
            var _return = new SqlConnection(connectionString);
            return new SqlConnection(connectionString);
        }
    }
}