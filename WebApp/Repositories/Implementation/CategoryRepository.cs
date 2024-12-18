﻿using DataAccessLayer;
using DataAccessLayer.Entities;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DemoDbContext _context;

        public CategoryRepository(DemoDbContext demoDbContext)
        {
            _context = demoDbContext;
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
