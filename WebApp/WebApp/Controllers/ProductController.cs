using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("productDetails")]
        public IActionResult GetProductInfo()
        {
            ViewBag.Title = "My Product Page";
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 1,
            };
            return View(productViewModel);
        }


    }
}
