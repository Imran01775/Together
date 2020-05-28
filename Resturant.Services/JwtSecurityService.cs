using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Resturant.Domain.Entities.Entities;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class JwtSecurityService : IJwtSecurityService
    {

        private readonly AppSettings _appSettings;

        public JwtSecurityService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public LoginResponse GetTokenCustomer(Customer response)
        {
            var tokenData = new LoginResponse();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretDataPattern);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, response.UserTypeId.ToString()),
                    new Claim(ClaimTypes.Role, "Customer"),
                    new Claim("Mobile", response.Mobile)
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenData.AuthenticationKey = tokenHandler.WriteToken(token);
            tokenData.UserTypeId = response.UserTypeId;
            return tokenData;
        }

        public LoginResponse GetTokenEmployee(Employee response)
        {
            var tokenData = new LoginResponse();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretDataPattern);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, response.UserTypeId.ToString()),
                    new Claim(ClaimTypes.Role, "Employee"),
                    new Claim("Mobile", response.Mobile)
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenData.AuthenticationKey = tokenHandler.WriteToken(token);
            tokenData.UserTypeId = response.UserTypeId;
            return tokenData;
        }

        
    }
}
