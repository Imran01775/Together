using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Services.Interfaces;

namespace Together.Controllers.ResturantOrder
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceEntry _orderEntry;
        private readonly IOrderServiceUpdate _orderUpdate;
        private readonly IOrderServiceDelete _orderDelete;
        private readonly IOrderItemServiceUpdate _orderItemUpdate;
        private readonly IOrderItemServiceDelete _orderItemDelete;
        public OrderController(IOrderServiceEntry orderEntry, IOrderServiceUpdate orderUpdate, IOrderServiceDelete orderDelete, IOrderItemServiceUpdate orderItemUpdate, IOrderItemServiceDelete orderItemDelete)
        {
            _orderEntry = orderEntry;
            _orderUpdate = orderUpdate;
            _orderDelete = orderDelete;
            _orderItemUpdate = orderItemUpdate;
            _orderItemDelete = orderItemDelete;
        }

        [HttpGet]
        [Route("GetOrderList/Index/Count")]
        public async Task<IActionResult> GetOrderList(int Index, int Count)
        {
            var response = new GetListDataResponse<OrderDTO>();
            try
            {

                response = await _orderEntry.GetOrderList(Index, Count);

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
        public async Task<IActionResult> OrderEntry([FromBody]OrderDTO orderDTO)
        {
            var response = new SingleResponseModel<OrderDTO>();
            try
            {

                var data = await _orderEntry.OrderEntry(orderDTO);
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
        public async Task<IActionResult> OrderUpdate([FromBody]OrderDTO orderDTO)
        {
            var response = new SingleResponseModel<OrderDTO>();
            try
            {

                var data = await _orderUpdate.OrderUpdate(orderDTO);
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
        public async Task<IActionResult> OrderDelete([FromBody]OrderDTO orderDTO)
        {
            var response = new SingleResponseModel<OrderDTO>();
            try
            {

                var data = await _orderDelete.OrderDelete(orderDTO);
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
        [Route("OrderItemUpdate")]
        public async Task<IActionResult> OrderItemUpdate([FromBody]OrderItemDTO orderItemDTO)
        {
            var response = new SingleResponseModel<OrderItemDTO>();
            try
            {

                var data = await _orderItemUpdate.OrderItemUpdate(orderItemDTO);
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
        [Route("OrderItemDelete")]
        public async Task<IActionResult> OrderItemDelete([FromBody]OrderItemDTO orderItemDTO)
        {
            var response = new SingleResponseModel<OrderItemDTO>();
            try
            {

                var data = await _orderItemDelete.OrderItemDelete(orderItemDTO);
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