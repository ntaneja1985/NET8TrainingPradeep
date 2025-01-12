using BusinessLayer.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class AuthAPIController(IUserBL userBL, IConfiguration configuration) : ControllerBase
    {

        [HttpPost]
        [Route("auth")]
        public IActionResult Authenticate(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel loggedInUser = userBL.ValidateUser(loginViewModel);
                if (!string.IsNullOrEmpty(loggedInUser.EmailId))
                {
                    string token = userBL.GenerateToken(loggedInUser);
                    return StatusCode(StatusCodes.Status200OK, new { message = "success", token = token });
                }

            }
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "failure" });
        }

    }
}
