using Microsoft.Data.SqlClient;
using Minesweeper.Data;
using Minesweeper.Models;
using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Services
{
    public class StatsSecurityDAO : StatsDAOInterface
    {
        Database database = new Database();
        StatsDBService service = new StatsDBService();

        public bool Create(PlayerStats model)
        {
            var dbConnect = database.DbConnection();
            return service.Create(model, dbConnect);
        }

        public bool Delete(int id)
        {
            var dbConnect = database.DbConnection();
            return service.Delete(id, dbConnect);
        }

        public List<PlayerStats> FindBy(string searchTerm)
        {
            var dbConnect = database.DbConnection();
            return service.FindBy(searchTerm, dbConnect);
        }

        public bool Update(PlayerStats stats)
        {
            var dbConnect = database.DbConnection();
            return service.Update(stats, dbConnect);
        }
    }
}
