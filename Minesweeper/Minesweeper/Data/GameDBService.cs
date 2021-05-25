using Microsoft.Data.SqlClient;
using Minesweeper.Models;
using MinesweeperClassLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class GameDBService
    {
        public bool PauseGame(Game game, SqlConnection dbConnection)
        {
            var success = false;

            string sqlStatement = "Insert into dbo.Game (Date, Difficulty, Result, Time, FlagsRemaining, Status, State) " +
                                  "VALUES (@Date, @Difficulty, @Result, @Time, @FlagsRemaining, @Status, @State)";

            var gameStateString = JsonConvert.SerializeObject(
                 game.State, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            // Prepared statement
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            command.Parameters.Add("@Date", System.Data.SqlDbType.NChar, 20).Value = DateTime.Now;
            command.Parameters.Add("@Difficulty", System.Data.SqlDbType.NChar, 20).Value = game.State.Difficulty;
            command.Parameters.Add("@Result", System.Data.SqlDbType.Bit).Value = game.Result;
            command.Parameters.Add("@Time", System.Data.SqlDbType.TinyInt).Value = DateTime.Now;
            command.Parameters.Add("@FlagsRemaining", System.Data.SqlDbType.NChar, 20).Value = game.FlagsRemaining;
            command.Parameters.Add("@Status", System.Data.SqlDbType.NVarChar, 50).Value = game.State;
            command.Parameters.Add("@State", System.Data.SqlDbType.NVarChar).Value = gameStateString;

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
            return success;
        }

        public Game ResumeGame(SqlConnection dbConnection)
        {
            Game game = new Game();

            return game;
        }
    }
}
