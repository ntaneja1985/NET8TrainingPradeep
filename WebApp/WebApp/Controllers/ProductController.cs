﻿using BusinessLayer.Abstraction;
using BusinessLayer.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductBL _productBL;
        private readonly ICategoryBL _categoryBL;

        public ProductController()
        {
            _productBL = new ProductBL();   
            _categoryBL = new CategoryBL();

        }
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
         var categories = new SelectList(_categoryBL.GetActiveCategories(),"CategoryId","CategoryName");
         ViewBag.Categories = categories;
         return View("CreateV1");   
        }

        
        [Route("save")]
        [HttpPost]
        public IActionResult SaveProduct(ProductViewModel productViewModel)
        {
            //Explicit Model Validation
            if (!string.IsNullOrEmpty(productViewModel.ProductName) && DuplicateProduct(productViewModel.ProductName))
            {
                ModelState.AddModelError("ProductName", "Product Name already exists");
            }
            if (ModelState.IsValid)
            {
                //save in db
               // products.Add(productViewModel);
               _productBL.AddProduct(productViewModel);
                return RedirectToAction("Summary");
            }
            else
            {
                var categories = new SelectList(_categoryBL.GetActiveCategories(), "CategoryId", "CategoryName");
                ViewBag.Categories = categories;
                return View("CreateV1");
            }
            
        }

        [HttpGet]
        [Route("product-list")]
        public IActionResult Summary(int view = 0)
        {
            if (view != 0)
            {
                return View("ProductsCard",_productBL.GetAllProducts());
            }
            else
            {
                return View("ProductList", _productBL.GetAllProducts());
            }
        }

        #region PrivateMethods
        private bool DuplicateProduct(string productName)
        {
            //check in db
            //var isExist = products.Where(x => x.ProductName.ToLower() == productName.ToLower()).Any();
            //return isExist;
            return _productBL.DuplicateCheck(productName, 0);
        }

        #endregion


    }
}
