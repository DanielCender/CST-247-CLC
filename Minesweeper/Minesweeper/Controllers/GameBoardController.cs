using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;

namespace Minesweeper.Controllers
{
    public class GameBoardController : Controller
    {
        static List<CellClass> Cells = new List<CellClass>();
        Random random = new Random();
        const int GRID_SIZE = 144;


        public IActionResult Index()
        {
            if (Cells.Count < GRID_SIZE)
            {
                for (int i = 0; i < GRID_SIZE; i++)
                {
                    Cells.Add(new CellClass { Id = i, CellState = random.Next(2), CellPic = 0, LiveNeighbors = 0 });
                }
            }
            
            return View(Cells);
        }
       

        //allows for Ajax/partial view to change the buttons
        public IActionResult RefreshButton(int buttonNumber)
        {
            //if the cell is a normal button and not flagged, make it appart as a visited picture
            if (Cells.ElementAt(buttonNumber).CellState == 0 && Cells.ElementAt(buttonNumber).flagged == false)
            {
                Cells.ElementAt(buttonNumber).CellPic = 1;
            }

            //if the cell is a bomb state and not flagged, make it appear as a bomb picture
            if (Cells.ElementAt(buttonNumber).CellState == 1 && Cells.ElementAt(buttonNumber).flagged == false)
            {
                Cells.ElementAt(buttonNumber).CellPic = 2;
            }

            return PartialView(Cells.ElementAt(buttonNumber));
        }


        //Change the button to a flag
        public IActionResult FlagButton(int buttonNumber)
        {
            if (Cells.ElementAt(buttonNumber).flagged == false)
            {
                Cells.ElementAt(buttonNumber).CellPic = 3;
                Cells.ElementAt(buttonNumber).flagged = true;
            }
            else
            {
                Cells.ElementAt(buttonNumber).CellPic = 0;
                Cells.ElementAt(buttonNumber).flagged = false;
            }
           
            return PartialView(Cells.ElementAt(buttonNumber));
        }
    }
}
