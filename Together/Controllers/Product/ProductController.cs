using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.Product
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProductList/Index/Count")]
        public async Task<IActionResult> GetProductList(int Index, int Count)
        {
            var response = new GetListDataResponse<ProductDTO>();
            try
            {

                response = await _productService.GetProductList(Index, Count);

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("EntryUpdate")]
        public async Task<IActionResult> ProductEntryUpdate([FromBody]ProductDTO productDTO)
        {
            var response = new SingleResponseModel<ProductDTO>();
            try
            {

                var data = await _productService.ProductEntryUpdate(productDTO);
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
        public async Task<IActionResult> ProductDelete([FromBody]ProductDTO productDTO)
        {
            var response = new SingleResponseModel<ProductDTO>();
            try
            {

                var data = await _productService.ProductDelete(productDTO);
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