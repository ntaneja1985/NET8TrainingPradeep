using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private static List<ProductViewModel> products = new List<ProductViewModel>()
        {
            new ProductViewModel() { Price = 5000, ProductCode = "P002", ProductName = "Bag", ProductId = 101 }
        };
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
                ProductId = 1,
                ProductName = "Test",
                ProductCode = "Test",
                Price = 1,
            };
            return View(productViewModel);
        }

        [Route("addProduct")]
        public IActionResult Create()
        {
         return View("CreateV1");   
        }

        
        [Route("save")]
        [HttpPost]
        public IActionResult SaveProduct(ProductViewModel productViewModel)
        {
            if (!string.IsNullOrEmpty(productViewModel.ProductName) && DuplicateProduct(productViewModel.ProductName))
            {
                ModelState.AddModelError("ProductName", "Product Name already exists");
            }
            if (ModelState.IsValid)
            {
                //save in db
                products.Add(productViewModel);
                return RedirectToAction("Summary");
            }
            else
            {
                return View("CreateV1");
            }
            
        }

        [HttpGet]
        [Route("product-list")]
        public IActionResult Summary(int view = 0)
        {
            if (view != 0)
            {
                return View("ProductsCard",products);
            }
            else
            {
                return View("ProductList", products);
            }
        }

        #region PrivateMethods
        private bool DuplicateProduct(string productName)
        {
            //check in db
            var isExist = products.Where(x => x.ProductName.ToLower() == productName.ToLower()).Any();
            return isExist;
        }

        #endregion


    }
}
