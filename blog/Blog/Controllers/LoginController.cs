using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Blog.ProjectData;

namespace Blog.Blog
{
    [Route("/login")]
    public class LoginController : Controller
    {
        private IUserProvider _userProvider;
        public LoginController(IUserProvider userProv)
        {
            _userProvider = userProv;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userProvider.FindByEmail(model.Email);
                if (user != null)
                {
                    await SecurityHelper.Authenticate(model.Email, HttpContext); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction("Login", "Account");
        }

    }
}