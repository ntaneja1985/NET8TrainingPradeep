using BusinessLayer.Abstraction;
using Repositories.Implementation;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ViewModels;

namespace BusinessLayer.Implementation
{
    public class UserBL(IUserRepository userRepository, IConfiguration configuration) : IUserBL
    {
        public UserViewModel ValidateUser(LoginViewModel loginViewModel)
        {
            var user = userRepository.ValidateUser(loginViewModel.EmailId, loginViewModel.Password);
            if(user == null)
            {
                return new UserViewModel { EmailId = "", Password = "" };
            }
            return new UserViewModel { EmailId = user.EmailId, Password = user.Password, FullName = user.FullName, Role = "Admin" };
        }

        public string GenerateToken(UserViewModel userVm)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? "");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userVm.FullName),
                new Claim(ClaimTypes.Email, userVm.EmailId),
                new Claim(ClaimTypes.Role, userVm.Role)
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            //parameters to generate the token
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(5),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
