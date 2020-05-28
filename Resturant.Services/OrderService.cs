using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class OrderService : IOrderServiceEntry, IOrderServiceUpdate, IOrderServiceDelete, IOrderItemServiceUpdate, IOrderItemServiceDelete
    {

        private readonly IOrderRepositoryEntry _orderEntry;
        private readonly IOrderRepositoryUpdate _orderUpdate;
        private readonly IOrderRepositoryDelete _orderDelete;
        private readonly IOrderItemRepositoryEntry _orderItemEntry;
        private readonly IOrderItemRepositoryUpdate _orderItemUpdate;
        private readonly IOrderItemRepositoryDelete _orderItemDelete;
        public OrderService(IOrderRepositoryEntry orderEntry, IOrderRepositoryUpdate orderUpdate, IOrderRepositoryDelete orderDelete, IOrderItemRepositoryEntry orderItemEntry, IOrderItemRepositoryUpdate orderItemUpdate, IOrderItemRepositoryDelete orderItemDelete)
        {
            _orderEntry = orderEntry;
            _orderUpdate = orderUpdate;
            _orderDelete = orderDelete;
            _orderItemEntry = orderItemEntry;
            _orderItemUpdate = orderItemUpdate;
            _orderItemDelete = orderItemDelete;
        }
        public async Task<OrderDTO> OrderDelete(OrderDTO orderDTO)
        {
            return await _orderDelete.OrderDelete(orderDTO);
        }

        public async Task<OrderDTO> OrderEntry(OrderDTO orderDTO)
        {
           return await _orderEntry.OrderEntry(orderDTO);
            
        }
        public async Task<List<OrderItemDTO>> OrderItemEntry(List<OrderItemDTO> orderItemDTO)
        {
            return await _orderItemEntry.OrderItemEntry(orderItemDTO);
        }
        public async Task<OrderItemDTO> OrderItemDelete(OrderItemDTO orderItemDTO)
        {
            return await _orderItemDelete.OrderItemDelete(orderItemDTO);
        }

        public async Task<OrderItemDTO> OrderItemUpdate(OrderItemDTO orderItemDTO)
        {
            return await _orderItemUpdate.OrderItemUpdate(orderItemDTO);
        }

        public async Task<OrderDTO> OrderUpdate(OrderDTO orderDTO)
        {
            return await _orderUpdate.OrderUpdate(orderDTO);
        }

        public async Task<GetListDataResponse<OrderDTO>> GetOrderList(int index, int count)
        {
            return await _orderEntry.GetOrderList(index,count);
        }
    }
}
