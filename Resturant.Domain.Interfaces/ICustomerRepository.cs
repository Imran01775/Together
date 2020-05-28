using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerDTO> CustomerDelete(CustomerDTO customerDTO);
        Task<CustomerDTO> CustomerEntry(CustomerDTO customerDTO);
        Task<CustomerDTO> CustomerUpdate(CustomerDTO customerDTO);
        Task<GetListDataResponse<CustomerDTO>> GetCustomerList(int index,int count);
    }
    public interface ICheckCustomerRepositoryExists
    {
        Task<CustomerDTO> CheckExistsCustomer(CustomerDTO employeeDTO);
    }
}
