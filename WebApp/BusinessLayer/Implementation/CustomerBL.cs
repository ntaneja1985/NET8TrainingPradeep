using BusinessLayer.Abstraction;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICategoryRepository _categoryRepository;
        public CustomerBL(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }
        public void GetCustomerData()
        {
            Console.WriteLine("Get customer data");
        }
    }
}
