using BusinessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController(IUserBL userBL) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel loggedInUser = userBL.ValidateUser(loginViewModel);
                if (loggedInUser != null && !string.IsNullOrEmpty(loggedInUser.EmailId))
                {
                    RedirectToAction("Create", "Product");
                }
               
            }
            ViewBag.InvalidUser = "Invalid email and password. Try again";
            return View("Index");
        }
    }
}
