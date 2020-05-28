using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Services.Interfaces
{
    
    public interface IOrderServiceEntry
    {
        Task<OrderDTO> OrderEntry(OrderDTO orderDTO);
        Task<GetListDataResponse<OrderDTO>> GetOrderList(int index, int count);
    }
    public interface IOrderServiceUpdate
    {
        Task<OrderDTO> OrderUpdate(OrderDTO orderDTO);
    }
    public interface IOrderServiceDelete
    {
        Task<OrderDTO> OrderDelete(OrderDTO orderDTO);
    }

    public interface IOrderItemServiceUpdate
    {
        Task<OrderItemDTO> OrderItemUpdate(OrderItemDTO orderItemDTO);
    }
    public interface IOrderItemServiceDelete
    {
        Task<OrderItemDTO> OrderItemDelete(OrderItemDTO orderItemDTO);
    }
}
