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

        public PlayerStats Create(PlayerStats model)
        {
            throw new NotImplementedException();
        }

        public PlayerStats Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PlayerStats FindBy(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public PlayerStats Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
