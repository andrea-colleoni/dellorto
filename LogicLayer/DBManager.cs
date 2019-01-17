using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace LogicLayer
{ 
    internal class DBManager
    {
        private const string DB_CATALOG = "DellOrtoLuraschi";

        internal static DbConnection getConnection()
        {
            string connectionString = String.Format(
            "Data Source=(local);Initial Catalog={0};"
            + "Integrated Security=true", DB_CATALOG);

            return new SqlConnection(connectionString);
        }
    }
}