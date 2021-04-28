using Microsoft.Data.SqlClient;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Services
{    
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CST-247-Minesweeper;Integrated Security=True;
                                Connect Timeout=30;
                                Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindByUsernameAndPassword(User user)
        {
            string sqlStatement = "Select * from dbo.Users where username = @Username AND password = @Password";

            bool success = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user.UserName;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // Return if found
            return success;
        }
    }
}
