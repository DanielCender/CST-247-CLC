using Microsoft.Data.SqlClient;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class Database
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CST-247-Minesweeper;Integrated Security=True;
                                Connect Timeout=30;
                                Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlConnection DbConnection()
        {
            // Get connection
            SqlConnection connection = new SqlConnection(connectionString);

            if (connection != null)
            {
                // Return connection
                return connection;
            }
            else
            {
                // Return null if connection failed
                return null;
            }
        }
    }
}
