using Microsoft.Data.SqlClient;
using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class UserDBService
    {        
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

        public User FindById(int id, SqlConnection dbConnection)
        {
            User user = new User();

            string sqlStatement = "Select * from dbo.Users where Id = @id";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared statement
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;            

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                        
                        user.UserId = reader.GetFieldValue<Int32>(reader.GetOrdinal("Id"));
                        user.FirstName = reader.GetFieldValue<String>(reader.GetOrdinal("FirstName"));
                        user.LastName = reader.GetFieldValue<String>(reader.GetOrdinal("LastName"));
                        user.Gender = reader.GetFieldValue<Byte>(reader.GetOrdinal("Gender"));
                        user.Age = reader.GetFieldValue<Int32>(reader.GetOrdinal("Age"));
                        user.State = reader.GetFieldValue<String>(reader.GetOrdinal("State"));
                        user.Email = reader.GetFieldValue<String>(reader.GetOrdinal("Email"));
                        user.UserName = reader.GetFieldValue<String>(reader.GetOrdinal("UserName"));
                        user.Password = reader.GetFieldValue<String>(reader.GetOrdinal("Password"));
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return user;
        }

        public bool FindByUsernameAndPassword(string username, string password, SqlConnection dbConnection)
        {            
            string sqlStatement = "Select * from dbo.Users where username = @Username AND password = @Password";

            // Will return true or false if found
            bool success = false;

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared statement
            command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;
            command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = password;

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

        public bool DeleteUser(int id, SqlConnection dbConnection)
        {
            // Will return true if deletion completed
            bool success = false;

            string sqlStatement = "DELETE from dbo.Users WHERE Id = @Id";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared Statement
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.RecordsAffected < 0)
                {
                    dbConnection.Close();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Return if User deleted
            return success;
        }

        public bool UpdateUser(int id, string column, string changeString, SqlConnection dbConnection)
        {
            var success = false;

            string sqlStatement = "Update dbo.Users set @column = @changeString WHERE Id = @Id";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared Statement
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@column", System.Data.SqlDbType.NVarChar).Value = column;
            command.Parameters.Add("@changeString", System.Data.SqlDbType.NVarChar).Value = changeString;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.RecordsAffected < 0)
                {
                    dbConnection.Close();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }

        public bool UpdateUser(int id, string column, int changeInt, SqlConnection dbConnection)
        {
            var success = false;

            string sqlStatement = "Update dbo.Users set @column = @changeInt WHERE Id = @Id";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared Statement
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@column", System.Data.SqlDbType.NVarChar).Value = column;
            command.Parameters.Add("@changeInt", System.Data.SqlDbType.Int).Value = changeInt;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.RecordsAffected < 0)
                {
                    dbConnection.Close();
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return success;
        }
    }
}
