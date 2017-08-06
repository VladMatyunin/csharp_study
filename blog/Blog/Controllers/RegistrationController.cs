using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.ProjectData;

namespace Blog.Blog
{
    public class RegistrationController : Controller
    {
        private IUserProvider _userProvider;
        public RegistrationController(IUserProvider userProv)
        {
            _userProvider = userProv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Register(RegistrationModel regModel)
        {
            if (ModelState.IsValid)
            {
                User enteredUser = await _userProvider.FindByEmail(regModel.Email);
                if (enteredUser == null)
                {
                    User createdUser = new User()
                    {
                        Email = regModel.Email,
                        Password = regModel.Password,
                        Name = regModel.Name,
                        Surname = regModel.Surname
                    };
                    await _userProvider.Create(createdUser);
                    await SecurityHelper.Authenticate(createdUser.Email, HttpContext);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "������������ ����� �(���) ������");
            return View(regModel);
        }
    }
}