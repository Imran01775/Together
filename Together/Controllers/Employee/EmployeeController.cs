using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.Employee
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        [Route("GetEmployeeList/Index/Count")]
        public async Task<IActionResult> GetEmployeeList(int Index, int Count)
        {
            var response = new GetListDataResponse<EmployeeDTO>();
            try
            {

                response = await _employeeService.GetEmployeeList(Index, Count);

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
        public async Task<IActionResult> EmployeeEntry([FromBody]EmployeeDTO employeeDTO)
        {
            var response = new SingleResponseModel<EmployeeDTO>();
            try
            {

                var data = await _employeeService.EmployeeEntry(employeeDTO);
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
        public async Task<IActionResult> EmployeeUpdate([FromBody]EmployeeDTO employeeDTO)
        {
            var response = new SingleResponseModel<EmployeeDTO>();
            try
            {

                var data = await _employeeService.EmployeeUpdate(employeeDTO);
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
        public async Task<IActionResult> EmployeeDelete([FromBody]EmployeeDTO employeeDTO)
        {
            var response = new SingleResponseModel<EmployeeDTO>();
            try
            {

                var data = await _employeeService.EmployeeDelete(employeeDTO);
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