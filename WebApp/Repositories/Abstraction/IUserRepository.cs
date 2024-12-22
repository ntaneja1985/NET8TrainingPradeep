﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Abstraction
{
    public interface IUserRepository
    {
        public User ValidateUser(string email,string password);
    }
}
