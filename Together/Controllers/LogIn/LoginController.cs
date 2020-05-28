using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.LogIn
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> LoginCustomer([FromBody]LoginDataModel loginDataModel)
        {
            var response = new SingleResponseModel<LoginResponse>();
            try
            {

                var data = await _loginService.LoginCustomer(loginDataModel);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpResponse();
        }
        [HttpPost]
        [Route("Employee")]
        public async Task<IActionResult> LoginEmployee([FromBody]LoginDataModel loginDataModel)
        {
            var response = new SingleResponseModel<LoginResponse>();
            try
            {

                var data = await _loginService.LoginEmployee(loginDataModel);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpResponse();
        }
    }
}