using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoDbContext _context;

        public ProductRepository()
        {
            _context = new DemoDbContext();
        }
        public bool Add(Product productToAdd)
        {
             _context.Products.Add(productToAdd);
            //context.SaveChanges gives the rows affected
            return _context.SaveChanges() > 0; //open connection, generate script, execute script, fetch latest id, insert, close connection
        }

        public bool Delete(int productId)
        {
            //_context.Products.Where(x => x.ProductId == productId).ExecuteDelete();
            //return _context.SaveChanges() > 0;
            var productToDelete = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            _context.Products.Remove(productToDelete);
            return  _context.SaveChanges() > 0;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = (from prod in  _context.Products
                            where prod.ProductId > 0 select prod).ToList();
            return products;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public bool Update(Product productToUpdate)
        {
            //_context.Products.Update(productToUpdate);
            //return _context.SaveChanges() > 0;
            //_context.Products.Where(x=>x.ProductId == productToUpdate.ProductId)
            //    .ExecuteUpdate(s=>s.SetProperty(p=>p.ProductCode, productToUpdate.ProductCode));
            _context.Entry<Product>(productToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
