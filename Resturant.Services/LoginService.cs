using Resturant.Domain.Entities;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtSecurityService _jwtSecurityService;
        public LoginService(ILoginRepository loginRepository, IJwtSecurityService jwtSecurityService)
        {
            _loginRepository = loginRepository;
            _jwtSecurityService = jwtSecurityService;
        }

        public async Task<LoginResponse> LoginCustomer(LoginDataModel loginDataModel)
        {
            var response =  _loginRepository.LoginCustomer(loginDataModel);

            if (response == null)
                return null;
              
            var responseData =  _jwtSecurityService.GetTokenCustomer(response);

            return await Task.FromResult(responseData); 
        }

        public async Task<LoginResponse> LoginEmployee(LoginDataModel loginDataModel)
        {
            var response =  _loginRepository.LoginEmployee(loginDataModel);
            if (response == null)
                return null;
            var responseData =  _jwtSecurityService.GetTokenEmployee(response);

            return await Task.FromResult(responseData);
        }
    }
}
