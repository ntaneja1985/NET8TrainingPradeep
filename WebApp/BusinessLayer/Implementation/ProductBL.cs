using BusinessLayer.Abstraction;
using DataAccessLayer.Entities;
using Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using Repositories.Abstraction;

namespace BusinessLayer.Implementation
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRepository _productRepo;
        private readonly ICustomerBL _customerBL;

        public ProductBL(IProductRepository productRepository, ICustomerBL customerBL)
        {
            _productRepo = productRepository;
            _customerBL = customerBL;
        }
        public bool AddProduct(ProductViewModel product)
        {
            Product productToAdd = new Product()
            {
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                Price = product.Price.Value,
                CategoryId = product.CategoryId,
            };
            return _productRepo.Add(productToAdd);
        }

        public bool DuplicateCheck(string productName, int productId)
        {
            //return _productRepo.GetAll().Any(x=>x.ProductName == productName);
            return _productRepo.DuplicateCheck(productName, productId);
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products =  _productRepo.GetAll();
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in products)
            {
                result.Add(new ProductViewModel() { ProductName = product.ProductName, ProductCode = product.ProductCode, Price = product.Price, ProductId = product.ProductId });
            }
            return result;
        }

        public ProductViewModel GetProductById(int id)
        {
            var productToEdit = _productRepo.GetProductById(id);
            return new ProductViewModel()
            {
                ProductName = productToEdit.ProductName,
                ProductCode = productToEdit.ProductCode,
                Price = productToEdit.Price,
                ProductId = productToEdit.ProductId,
                CategoryId= productToEdit.CategoryId
            };
        }

        public bool RemoveProduct(int id)
        {
           return _productRepo.Delete(id);
        }

        public bool UpdateProduct(ProductViewModel product)
        {
            Product productToUpdate = new Product()
            {
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                Price = product.Price.Value,
                ProductId = product.ProductId.Value,
                CategoryId = product.CategoryId,
               
            };
            return _productRepo.Update(productToUpdate);
        }
    }
}
