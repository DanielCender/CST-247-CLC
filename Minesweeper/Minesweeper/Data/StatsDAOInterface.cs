using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface StatsDAOInterface
    {
        public bool Create(PlayerStats model);
        public bool Update(PlayerStats model);
        public bool Delete(int id);
        public List<PlayerStats> FindBy(string searchTerm);
    }
}
