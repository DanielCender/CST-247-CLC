using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }       
    }    
}
