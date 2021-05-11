using System;
namespace Minesweeper.Models
{
    public class CellClass
    {
        public int Id { get; set; }
        public int CellState { get; set; } // two states visited and bomb/live
        public int CellPic { get; set; } // set for the picture
        public int LiveNeighbors { get; set; } 
    }
}
