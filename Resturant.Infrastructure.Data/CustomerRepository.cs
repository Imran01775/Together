using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository, ICheckCustomerRepositoryExists
    {

        private readonly SqlServerContext _sqlServerContext;
        public CustomerRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public async Task<CustomerDTO> CheckExistsCustomer(CustomerDTO customerDTO)
        {
            var response = await _sqlServerContext.Customer.Where(v => v.Mobile.Trim() == customerDTO.Mobile.Trim()).FirstOrDefaultAsync();
            if (response != null)
                return customerDTO;
            else
                return null;

        }

        public async Task<CustomerDTO> CustomerDelete(CustomerDTO customerDTO)
        {
            var dataObejct = customerDTO as CustomerDTO;
            _sqlServerContext.Remove(customerDTO);
            await _sqlServerContext.SaveChangesAsync();
            return customerDTO;
        }

        public async Task<CustomerDTO> CustomerEntry(CustomerDTO customerDTO)
        {
            var dataObejct = customerDTO as CustomerDTO;
            await _sqlServerContext.AddAsync(customerDTO);
            await _sqlServerContext.SaveChangesAsync();
            return customerDTO;
        }

        public async Task<CustomerDTO> CustomerUpdate(CustomerDTO customerDTO)
        {
            var dataObejct = customerDTO as CustomerDTO;
            _sqlServerContext.Update(customerDTO);
            await _sqlServerContext.SaveChangesAsync();
            return customerDTO;
        }

        public async Task<GetListDataResponse<CustomerDTO>> GetCustomerList(int index, int count)
        {
            var response = new GetListDataResponse<CustomerDTO>();
            response.TotalCount = 10;
            response.Model = await (from customer in _sqlServerContext.Customer

                                    select new CustomerDTO
                                    {
                                        Name = customer.Name
                                    }).ToListAsync();
            return response;

        }
    }
}
