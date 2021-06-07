using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minesweeper.Models;
using Minesweeper.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Authenticate(string username, string password)
        {
            UserSecurityDAO securityService = new UserSecurityDAO();
            //var result = securityService.FindByUsernameAndPassword(username, password);
            var result = securityService.FindById(1);

            if (result != null)
            {
                //var jsonString = JsonConvert.SerializeObject(
                     //result, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
                //return Redirect("/Game/Index");
                return Redirect("/GameBoard");
            }
            else
            {
                return View("LoginFailure", username);
            }
        }        
    }
}
