using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface StatsDAOInterface
    {
        PlayerStats Create(PlayerStats model);
        PlayerStats Update(int id);
        PlayerStats Delete(int id);
        PlayerStats FindBy(string searchTerm);
    }
}
