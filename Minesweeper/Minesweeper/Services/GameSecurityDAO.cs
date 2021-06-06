using Minesweeper.Data;
using Minesweeper.Models;
using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Services
{
    public class GameSecurityDAO : GameDAOInterface
    {
        Database database = new Database();
        GameDBService service = new GameDBService();

        public Game FindById(int id)
        {
            var dbConnection = database.DbConnection();
            return service.FindById(id, dbConnection);
        }

        public bool PauseGame(Game game)
        {
            var dbConnection = database.DbConnection();
            return service.PauseGame(game, dbConnection);            
        }

        public Game ResumeGame(int id)
        {
            var dbConnection = database.DbConnection();
            return service.ResumeGame(dbConnection);
        }
    }
}
