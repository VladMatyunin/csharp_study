using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("login");
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            
            return null; 
        }

        public ActionResult Logout()
        {
            return null;
        }

    }
}