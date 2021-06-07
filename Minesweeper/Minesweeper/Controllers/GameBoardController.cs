using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using MinesweeperClassLib;

namespace Minesweeper.Controllers
{
    public class GameBoardController : Controller
    {
        static Board gameBoard;
        const int GRID_SIZE = 12; // 144 when squared

        public IActionResult Index()
        {
            gameBoard = new Board(10, GRID_SIZE);
            
            return View(gameBoard);
        }
       

        //allows for Ajax/partial view to change the buttons
        public IActionResult RefreshButton(int buttonRow, int buttonCol)
        {
            Cell clicked = gameBoard.Grid[buttonRow, buttonCol];

            // Check for a losing state
            int gameState = HasGameEnded(gameBoard, buttonRow, buttonCol, false);

            // 
            /*if (gameState == 0)
            {
                gameBoard.floodFill(buttonRow, buttonCol);
            }*/

            // We need to reveal all adjacent clear neighbors
            // gameBoard.CalculateLiveNeighbors();

            /* if(gameState == 0) return View("Index", gameBoard);*/

            /*    if (gameState == 1) return Redirect("GameLost");
                if (gameState == 2) return Redirect("GameWon");*/

            clicked.Visited = true;
            return PartialView(clicked);
        }


        //Change the button to a flag
        public IActionResult FlagButton(int buttonRow, int buttonCol)
        {
            Cell clicked = gameBoard.Grid[buttonRow, buttonCol];
            clicked.Flagged = !clicked.Flagged;

            return PartialView(clicked);
        }

        // Result: 0 for no, 1 for loss, 2 for win
        private int HasGameEnded(Board board, int row, int col, bool flagAttempt)
        {
            // Check if mouse button was a right click
            if (flagAttempt)
            {
                board.Grid[row, col].Flagged = !board.Grid[row, col].Flagged;
                return 0;
            }

            // Check if the button is already flagged. If so, do nothing
            if (board.Grid[row, col].Flagged)
            {
                return 0;
            }

            // Check if user hit a bomb
            if (board.Grid[row, col].Live)
            {
                // Reveal all bombs
                for (int r = 0; r < board.Grid.GetLength(0); r++)
                {
                    for (int c = 0; c < board.Grid.GetLength(1); c++)
                    {
                        // Set all live or previously-visited tiles to Visited so UI exposes all hidden mines
                        board.Grid[r, c].Visited = board.Grid[r, c].Visited || board.Grid[r, c].Live;
                    }
                }
                return 1;
            }

            board.Grid[row, col].Visited = true;
            return 1;
        }
    }
}
