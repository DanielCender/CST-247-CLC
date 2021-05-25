using Microsoft.Data.SqlClient;
using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class StatsDBService
    {
        public bool Create(PlayerStats model, SqlConnection dbConnection)
        {
            string sqlStatement = "Insert into dbo.Stats (Wins, Losses, Total, AverageTime, BestTime, UserId) " +
                                  "VALUES (@Wins, @Losses, @Total, @AverageTime, @BestTime, @UserId)";

            // Will return true or false if registered.
            bool success = false;

            // Prepared statement
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            command.Parameters.Add("@Wins", System.Data.SqlDbType.Int).Value = model.Wins;
            command.Parameters.Add("@Losses", System.Data.SqlDbType.Int).Value = model.Losses;
            command.Parameters.Add("@Total", System.Data.SqlDbType.Int).Value = model.Total;
            command.Parameters.Add("@AverageTime", System.Data.SqlDbType.DateTime).Value = model.AverageTime;
            command.Parameters.Add("@BestTime", System.Data.SqlDbType.DateTime).Value = model.BestTime;
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = model.PlayerId;


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

        public bool Delete(int id, SqlConnection dbConnection)
        {
            // Will return true if deletion completed
            bool success = false;

            string sqlStatement = "DELETE from dbo.Stats WHERE Id = @Id";

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

        public List<PlayerStats> FindBy(string searchTerm, SqlConnection dbConnection)
        {
            List<PlayerStats> statsList = new List<PlayerStats>();

            string sqlStatement = "Select * FROM dbo.Stats WHERE Wins LIKE '%@searchTerm%' OR " +
                                                                "Losses LIKE '%@searchTerm%' OR " +
                                                                "Total LIKE '%@searchTerm%' OR " +
                                                                "AverageTime LIKE '%@searchTerm%' OR " +
                                                                "BestTime LIKE '%@searchTerm%'";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared statement
            command.Parameters.Add("@searchTerm", System.Data.SqlDbType.NVarChar).Value = searchTerm;

            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PlayerStats stats = new PlayerStats();

                        stats.Wins= reader.GetFieldValue<Int32>(reader.GetOrdinal("Wins"));
                        stats.Losses = reader.GetFieldValue<Int32>(reader.GetOrdinal("Losses"));
                        stats.Total = reader.GetFieldValue<Int32>(reader.GetOrdinal("Total"));
                        stats.AverageTime = reader.GetFieldValue<DateTime>(reader.GetOrdinal("AverageTime"));
                        stats.BestTime = reader.GetFieldValue<DateTime>(reader.GetOrdinal("BestTime"));
                        stats.PlayerId = reader.GetFieldValue<String>(reader.GetOrdinal("UserId"));

                        statsList.Add(stats);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return statsList;
        }

        public bool Update(PlayerStats model, SqlConnection dbConnection)
        {
            var success = false;

            string sqlStatement = "Update dbo.Users set Wins = @Wins, " +
                                                       "Losses = @Losses," +
                                                       "Total = @Total," +
                                                       "AverageTime = @AverageTime" +
                                                       "BestTime = @BestTime" +
                                                       "UserId = @UserId" +
                                  "WHERE Id = @Id";

            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);

            // Prepared Statement
            command.Parameters.Add("@Wins", System.Data.SqlDbType.Int).Value = model.Wins;
            command.Parameters.Add("@Losses", System.Data.SqlDbType.NVarChar).Value = model.Losses;
            command.Parameters.Add("@Total", System.Data.SqlDbType.Int).Value = model.Total;
            command.Parameters.Add("@AverageTime", System.Data.SqlDbType.DateTime).Value = model.AverageTime;
            command.Parameters.Add("@BestTime", System.Data.SqlDbType.Date).Value = model.BestTime;
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = model.PlayerId;

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
