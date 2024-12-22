using BusinessLayer.Abstraction;
using Repositories.Implementation;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer.Implementation
{
    public class UserBL(IUserRepository userRepository) : IUserBL
    {
        public UserViewModel ValidateUser(LoginViewModel loginViewModel)
        {
            var user = userRepository.ValidateUser(loginViewModel.EmailId, loginViewModel.Password);
            if(user == null)
            {
                return new UserViewModel { EmailId = "", Password = "" };
            }
            return new UserViewModel { EmailId = user.EmailId, Password = user.Password, FullName = user.FullName, Token = "" };
        }
    }
}
