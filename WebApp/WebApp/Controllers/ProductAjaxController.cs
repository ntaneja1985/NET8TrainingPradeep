using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductAjaxController: Controller
    {
        public IActionResult Index() 
        { 
            return View(); 
        }
    }
}
