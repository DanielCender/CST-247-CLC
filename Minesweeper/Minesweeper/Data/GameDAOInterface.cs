using Minesweeper.Models;
using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    interface GameDAOInterface
    {
        public Game FindById(int id);
        public bool SaveGame(Game game);

        // NOT NEEDED - public Game ResumeGame(int id);
    }
}
