using DataAccessLayer;
using DataAccessLayer.Entities;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class UserRepository(DemoDbContext dbContext) : IUserRepository
    {
        
        public User ValidateUser(string email, string password)
        {
          return dbContext.Users.Where(x=>x.EmailId == email && x.Password == password).FirstOrDefault();
        }
    }
}
