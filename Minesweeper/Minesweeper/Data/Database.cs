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

        internal bool RegisterUser(User user, SqlConnection dbConnection)
        {
            string sqlStatement = "Insert into dbo.Users (FirstName, LastName, Gender, Age, State, Email, Username, Password) " +
                                  "VALUES (@FirstName, @LastName, @Gender, @Age, @State, @Email, @Username, @Password)";

            // Will return true or false if registered.
            bool success = false;

            // Prepared statement
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            command.Parameters.Add("@FirstName", System.Data.SqlDbType.NChar, 20).Value = user.FirstName;
            command.Parameters.Add("@LastName", System.Data.SqlDbType.NChar, 20).Value = user.LastName;
            command.Parameters.Add("@Gender", System.Data.SqlDbType.Bit).Value = user.Gender;
            command.Parameters.Add("@Age", System.Data.SqlDbType.TinyInt).Value = user.Age;
            command.Parameters.Add("@State", System.Data.SqlDbType.NChar, 20).Value = user.State;
            command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = user.Email;
            command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user.UserName;
            command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.RecordsAffected > 0)
                {
                    dbConnection.Close();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Return registration result
            return success;
        }

        public bool FindByUsernameAndPassword(User user, SqlConnection dbConnection)
        {            
            string sqlStatement = "Select * from dbo.Users where username = @Username AND password = @Password";

            // Will return true or false if found
            bool success = false;

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared statement
            command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user.UserName;
            command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dbConnection.Close();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Return if found
            return success;
        }
    }
}
