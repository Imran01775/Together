using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.Common
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        private readonly IStatusService _statusService;
        private readonly ILocationService _locationService;
        public CommonController(IUserTypeService userTypeService, IStatusService statusService, ILocationService locationService)
        {
            _userTypeService = userTypeService;
            _statusService = statusService;
            _locationService = locationService;
        }
        [HttpPost]
        [Route("UserTypeEntryUpdate")]
        public async Task<IActionResult> UserTypeEntryUpdate([FromBody]UserTypeDTO userTypeDTO)
        {
            var response = new SingleResponseModel<UserTypeDTO>();
            try
            {

                var data = await _userTypeService.UserTypeEntryUpdate(userTypeDTO);
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
        [Route("UserTypeDelete")]
        public async Task<IActionResult> UserTypeDelete([FromBody]UserTypeDTO userTypeDTO)
        {
            var response = new SingleResponseModel<UserTypeDTO>();
            try
            {

                var data = await _userTypeService.UserTypeDelete(userTypeDTO);
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
        [Route("LocationEntryUpdate")]
        public async Task<IActionResult> LocationEntryUpdate([FromBody]LocationDTO locationDTO)
        {
            var response = new SingleResponseModel<LocationDTO>();
            try
            {

                var data = await _locationService.LocationEntryUpdate(locationDTO);
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
        [Route("LocationDelete")]
        public async Task<IActionResult> LocationDelete([FromBody]LocationDTO locationDTO)
        {
            var response = new SingleResponseModel<LocationDTO>();
            try
            {

                var data = await _locationService.LocationDelete(locationDTO);
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
        [Route("StatusEntry")]
        public async Task<IActionResult> StatusEntryUpdate([FromBody]StatusDTO statusDTO)
        {
            var response = new SingleResponseModel<StatusDTO>();
            try
            {

                var data = await _statusService.StatusEntryUpdate(statusDTO);
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
        [Route("StatusDelete")]
        public async Task<IActionResult> StatusDelete([FromBody]StatusDTO statusDTO)
        {
            var response = new SingleResponseModel<StatusDTO>();
            try
            {

                var data = await _statusService.StatusDelete(statusDTO);
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