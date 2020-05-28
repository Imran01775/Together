using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.Resturant
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService _itestService = null;
        public TestController(ITestService itestService)
        {
            _itestService = itestService;
        }
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Save([FromBody]TestModel testModel)
        {

            var response = new SingleResponseModel<TestModel>();

            try
            {
                var data = await _itestService.Save(testModel);
                response.Model = data;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpCreatedResponse();
        }
    }
}