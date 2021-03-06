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
        public Game FindById(int id, SqlConnection dbConnection)
        {
            string sqlStatement = "SELECT * FROM dbo.Game WHERE Id = @Id";
           
            // Prepared statement
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                dbConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Game game = new Game();

                    // Get all column ordinals
                    int idOrdinal = reader.GetOrdinal("Id");
                    int dateOrdinal = reader.GetOrdinal("Date");
                    int difficultyOrdinal = reader.GetOrdinal("Difficulty");
                    int resultOrdinal = reader.GetOrdinal("Result");
                    int timeOrdinal = reader.GetOrdinal("Time");
                    int flagsRemainingOrdinal = reader.GetOrdinal("FlagsRemaining");
                    int statusOrdinal = reader.GetOrdinal("Status");
                    int stateOrdinal = reader.GetOrdinal("State");
                    string boardSavedState = "";

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(idOrdinal)) game.Id = reader.GetFieldValue<Int32>(idOrdinal);
                        if (!reader.IsDBNull(dateOrdinal))
                            game.Date = reader.GetFieldValue<DateTime>(dateOrdinal);
     
                        if (!reader.IsDBNull(difficultyOrdinal))
                            game.Difficulty = reader.GetFieldValue<String>(difficultyOrdinal);
                       
                        if (!reader.IsDBNull(resultOrdinal))
                            game.Result = reader.GetFieldValue<Int32>(resultOrdinal);
                       
                        if (!reader.IsDBNull(timeOrdinal))
                            game.Time = reader.GetFieldValue<Int32>(timeOrdinal);
                       
                        if (!reader.IsDBNull(flagsRemainingOrdinal))
                            game.FlagsRemaining = reader.GetFieldValue<Int32>(flagsRemainingOrdinal);
                        
                        if (!reader.IsDBNull(statusOrdinal))
                            game.Status = reader.GetFieldValue<Int32>(statusOrdinal);
                        
                        if (!reader.IsDBNull(stateOrdinal))
                            boardSavedState = reader.GetFieldValue<String>(stateOrdinal);

                        // Convert stringified JSON to game instance
                        if(boardSavedState.Length > 0)
                            game.State = JsonConvert.DeserializeObject<Board>(
                        boardSavedState, new JsonConverter[] { new StringEnumConverter() });

                    }
                    dbConnection.Close();
                    return game;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                dbConnection.Close();
            }
            return null;
        }
        public bool SaveGame(Game game, SqlConnection dbConnection)
        {
            Game saved = null;
            bool exists = false;

            if (game.Id == 0)
            {
                saved = FindById(game.Id, dbConnection);
                exists = true;
            }

            var success = false;
            string sqlStatement = "";

            if(exists)
            {
                sqlStatement = "UPDATE dbo.Game SET UserId = @UserId, Date = @Date, Difficulty = @Difficulty, Result = @Result, " +
                                   "Time = @Time, FlagsRemaining = @FlagsRemaining, Status = @Status, State = @State) " +
                                   "WHERE Id = @Id";
            } else
            {
                sqlStatement = "Insert into dbo.Game (UserId, Date, Difficulty, Result, Time, FlagsRemaining, Status, State) " +
                                  "VALUES (@UserId, @Date, @Difficulty, @Result, @Time, @FlagsRemaining, @Status, @State)";
            }
            var gameStateString = JsonConvert.SerializeObject(
                 game.State, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            // Prepared statement
            SqlCommand command = new SqlCommand(sqlStatement, dbConnection);
            if (exists) command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = game.Id;
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = saved != null && game.UserId != saved.UserId ? game.UserId : saved.UserId;
            command.Parameters.Add("@Date", System.Data.SqlDbType.NChar, 20).Value = DateTime.Now;
            command.Parameters.Add("@Difficulty", System.Data.SqlDbType.NChar, 20).Value = game.State.Difficulty;
            command.Parameters.Add("@Result", System.Data.SqlDbType.Bit).Value = game.Result;
            command.Parameters.Add("@Time", System.Data.SqlDbType.Int).Value = game.Time;
            command.Parameters.Add("@FlagsRemaining", System.Data.SqlDbType.NChar, 20).Value = game.FlagsRemaining;
            command.Parameters.Add("@Status", System.Data.SqlDbType.Bit).Value = game.Status;
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

        // Not Needed
       /* public Game ResumeGame(int id, SqlConnection dbConnection)
        {
            Game game = new Game();


            // Get Ordinal values

            return game;
            throw new NotImplementedException();
        }*/
    }
}
