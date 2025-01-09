using BusinessLayer.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
                if (!string.IsNullOrEmpty(loggedInUser.EmailId))
                {
                    string token = userBL.GenerateToken(loggedInUser);
                    HttpContext.Response.Cookies.Append("AuthToken", token);
                    return RedirectToAction("Create", "Product");
                }
               
            }
            ViewBag.InvalidUser = "Invalid email and password. Try again";
            return View("Index");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Login");
        }
    }
}
