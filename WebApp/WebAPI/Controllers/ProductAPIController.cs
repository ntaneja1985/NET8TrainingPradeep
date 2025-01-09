using BusinessLayer.Abstraction;
using BusinessLayer.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductBL _productBL;
        public ProductAPIController(IProductBL productBL)
        {
            _productBL = productBL;
        }


        [Route("getall")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productBL.GetAllProducts();
            //return Ok(products);
            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct([FromBody] ProductViewModel productVM)
        {
            var isAdded = _productBL.AddProduct(productVM);
            if (isAdded)
            {
                return StatusCode(StatusCodes.Status201Created, isAdded);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, isAdded);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productBL.RemoveProduct(id);
            if (isDeleted)
            {
                return StatusCode(StatusCodes.Status204NoContent, isDeleted);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, isDeleted);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateProduct(ProductViewModel productVM)
        {
            var isUpdated = _productBL.UpdateProduct(productVM);
            if (isUpdated)
            {
                return StatusCode(StatusCodes.Status200OK, isUpdated);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, isUpdated);
            }
        }

       
        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            var product = _productBL.GetProductById(id);
            //return Ok(products);
            return StatusCode(StatusCodes.Status200OK, product);
        }
    }
}
