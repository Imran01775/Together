using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.Customer
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomerList/Index/Count")]
        public async Task<IActionResult> GetCustomerList(int Index, int Count)
        {
            var response = new GetListDataResponse<CustomerDTO>();
            try
            {

                response = await _customerService.GetCustomerList(Index, Count);

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("Entry")]
        public async Task<IActionResult> CustomerEntry([FromBody]CustomerDTO customerDTO)
        {
            var response = new SingleResponseModel<CustomerDTO>();
            try
            {

                var data = await _customerService.CustomerEntry(customerDTO);
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
        [Route("Update")]
        public async Task<IActionResult> CustomerUpdate([FromBody]CustomerDTO customerDTO)
        {
            var response = new SingleResponseModel<CustomerDTO>();
            try
            {

                var data = await _customerService.CustomerUpdate(customerDTO);
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
        [Route("Delete")]
        public async Task<IActionResult> CustomerDelete([FromBody]CustomerDTO customerDTO)
        {
            var response = new SingleResponseModel<CustomerDTO>();
            try
            {

                var data = await _customerService.CustomerDelete(customerDTO);
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