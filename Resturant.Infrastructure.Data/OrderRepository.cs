using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.Entities;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{
    public class OrderRepository : IOrderRepositoryEntry, IOrderRepositoryUpdate, IOrderRepositoryDelete, IOrderItemRepositoryEntry, IOrderItemRepositoryUpdate, IOrderItemRepositoryDelete
    {
        private readonly SqlServerContext _sqlServerContext;
        public OrderRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public async Task<GetListDataResponse<OrderDTO>> GetOrderList(int index, int count)
        {
            var response = new GetListDataResponse<OrderDTO>();
            response.Model = await (from order in _sqlServerContext.Order

                                    select new OrderDTO
                                    {
                                        OrderId = order.OrderId
                                    }
                                    ).ToListAsync();
            return response;
        }

        public async Task<OrderDTO> OrderDelete(OrderDTO orderDTO)
        {
            var dataObject = orderDTO as ResturantOrder;
            _sqlServerContext.Remove<ResturantOrder>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return orderDTO;
        }
        //order place
        public async Task<OrderDTO> OrderEntry(OrderDTO orderDTO)
        {

            try
            {
                using (var transaction = await _sqlServerContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        orderDTO.OrderItemDTO = orderDTO.OrderItemDTO.Select(v => { v.TotalPrice = v.ProductQuantity * v.SellUnitPrice; return v; }).ToList();
                        orderDTO.Price = orderDTO.OrderItemDTO.Sum(x => x.TotalPrice);
                        orderDTO.OrderTotalCostAmount = orderDTO.OrderItemDTO.Sum(c => ((decimal)c.TotalPrice * (decimal)c.ProductCostPercentage) / 100);
                        orderDTO.CompanyAmount = orderDTO.OrderItemDTO.Sum(c => ((decimal)c.TotalPrice * (decimal)c.CompanyPercentage) / 100);
                        orderDTO.CustomerAmount = orderDTO.OrderItemDTO.Sum(c => ((decimal)c.TotalPrice * (decimal)c.CustomerPercentage) / 100);
                        var dataObject = orderDTO as ResturantOrder;
                        await _sqlServerContext.AddAsync<ResturantOrder>(dataObject);
                        await _sqlServerContext.SaveChangesAsync();
                        orderDTO.OrderItemDTO = orderDTO.OrderItemDTO.Select(c => { c.OrderId = orderDTO.OrderId; return c; }).ToList();
                        await OrderItemEntry(orderDTO.OrderItemDTO);
                        await _sqlServerContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return orderDTO;
                    }
                    catch (Exception exp)
                    {
                        orderDTO = null;
                        await transaction.RollbackAsync();
                        return null;
                    }

                }

            }
            catch (Exception exp)
            {
                throw exp;
            }



        }

        public async Task<OrderItemDTO> OrderItemDelete(OrderItemDTO orderItemDTO)
        {
            var dataObject = orderItemDTO as Order_Item;
            _sqlServerContext.Remove<Order_Item>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return orderItemDTO;

        }

        public async Task<List<OrderItemDTO>> OrderItemEntry(List<OrderItemDTO> orderItemDTO)
        {
            var dataObject = orderItemDTO.Cast<Order_Item>().ToList();// orderItemDTO as Order_Item;
            await _sqlServerContext.AddRangeAsync(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return orderItemDTO;
        }

        public async Task<OrderItemDTO> OrderItemUpdate(OrderItemDTO orderItemDTO)
        {
            var dataObject = orderItemDTO as Order_Item;
            _sqlServerContext.Update<Order_Item>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return orderItemDTO;
        }

        public async Task<OrderDTO> OrderUpdate(OrderDTO orderDTO)
        {
            var dataObject = orderDTO as ResturantOrder;
            _sqlServerContext.Update<ResturantOrder>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return orderDTO;
        }
    }
}
