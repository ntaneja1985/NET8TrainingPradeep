﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstraction
{
    internal interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}