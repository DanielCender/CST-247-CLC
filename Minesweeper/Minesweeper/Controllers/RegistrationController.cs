using Microsoft.AspNetCore.Mvc;
using Minesweeper.Models;
using Minesweeper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Register(string FirstName, string LastName, string Gender, int Age, string State, string Email, string Password)
        {
            User user = new User();

            user.FirstName = FirstName;
            user.LastName = LastName;
            if (Gender == "Male")
            {
                user.Gender = false;
            }
            else if (Gender == "Female")
            {
                user.Gender = true;
            }
            user.Age = Age;
            user.State = State;
            user.Email = Email;
            user.UserName = "sBlackwing";
            user.Password = Password;
            
            SecurityDAO securityService = new SecurityDAO();
            var result = securityService.Create(user);

            if (result)
            {
                //return Content("Login Success!");
                return View("RegisterSuccess", user);
            }
            else
            {
                //return Content("Login Failure...");
                return View("RegisterFailure", user);
            }
        }
    }
}
