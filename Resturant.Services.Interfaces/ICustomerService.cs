using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CustomerEntry(CustomerDTO customerDTO);
        Task<CustomerDTO> CustomerUpdate(CustomerDTO customerDTO);
        Task<CustomerDTO> CustomerDelete(CustomerDTO customerDTO);
        Task<GetListDataResponse<CustomerDTO>> GetCustomerList(int index,int count);
    }
    public interface ICheckCustomerServiceExists
    {
        Task<CustomerDTO> CheckExistsCustomer(CustomerDTO employeeDTO);
    }
}
