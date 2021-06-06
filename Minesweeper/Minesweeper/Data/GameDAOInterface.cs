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
        public bool PauseGame(Game game);

        public Game ResumeGame();
    }
}
