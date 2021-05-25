using MinesweeperClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    [Serializable]
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Difficulty { get; set; }
        public int Result { get; set; }
        public DateTime Time { get; set; }
        public int FlagsRemaining { get; set; }
        public int Status { get; set; }
        public Board State { get; set; }
    }
}
