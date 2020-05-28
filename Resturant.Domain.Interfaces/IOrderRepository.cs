using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain.Interfaces
{
    public interface IOrderRepositoryEntry
    {
        Task<OrderDTO> OrderEntry(OrderDTO orderDTO);
        Task<GetListDataResponse<OrderDTO>> GetOrderList(int index, int count);
    }
    public interface IOrderRepositoryUpdate
    {
        Task<OrderDTO> OrderUpdate(OrderDTO orderDTO);
    }
    public interface IOrderRepositoryDelete
    {
        Task<OrderDTO> OrderDelete(OrderDTO orderDTO);
    }
    public interface IOrderItemRepositoryEntry
    {
        Task<List<OrderItemDTO>> OrderItemEntry(List<OrderItemDTO> orderItemDTO);
    }
    public interface IOrderItemRepositoryUpdate
    {
        Task<OrderItemDTO> OrderItemUpdate(OrderItemDTO orderItemDTO);
    }
    public interface IOrderItemRepositoryDelete
    {
        Task<OrderItemDTO> OrderItemDelete(OrderItemDTO orderItemDTO);
    }
}
