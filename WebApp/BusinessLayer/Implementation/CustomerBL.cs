﻿using BusinessLayer.Abstraction;
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
        private static int counter = 0;
        public CustomerBL(ICategoryRepository categoryRepository,string data)
        {
            counter++;
            Console.WriteLine($"Object created: {counter}");
            _categoryRepository = categoryRepository;   
        }
        public void GetCustomerData()
        {
            Console.WriteLine("Get customer data");
        }
    }
}
