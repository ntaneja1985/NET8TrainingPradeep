using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer.Abstraction
{
    public interface IProductBL
    {
       IEnumerable<ProductViewModel> GetAllProducts();
        bool AddProduct(ProductViewModel product);

        bool UpdateProduct(ProductViewModel product);

        ProductViewModel GetProductById(int id);

        bool RemoveProduct(int id);

        bool DuplicateCheck(string productName, int productId);
    }
}
