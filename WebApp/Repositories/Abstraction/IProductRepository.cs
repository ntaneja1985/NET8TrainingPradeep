using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstraction
{
    internal interface IProductRepository
    {
        bool Add(Product productToAdd);
        bool Update(Product productToUpdate); 
        
        bool Delete(int productId);
        IEnumerable<Product> GetAll();

        Product GetProductById(int productId);
    }
}
