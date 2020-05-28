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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICheckCustomerRepositoryExists _checkCustomerRepositoryExists;
        public CustomerService(ICustomerRepository customerRepository, ICheckCustomerRepositoryExists checkCustomerRepositoryExists)
        {
            _checkCustomerRepositoryExists = checkCustomerRepositoryExists;
            _customerRepository = customerRepository;
        }
        public async Task<CustomerDTO> CustomerDelete(CustomerDTO customerDTO)
        {
            return await _customerRepository.CustomerDelete(customerDTO);
        }

        public async Task<CustomerDTO> CustomerEntry(CustomerDTO customerDTO)
        {
            var response = await _checkCustomerRepositoryExists.CheckExistsCustomer(customerDTO);

            if (response == null)
                response= await _customerRepository.CustomerEntry(customerDTO);

            return response;


        }

        public async Task<CustomerDTO> CustomerUpdate(CustomerDTO customerDTO)
        {
            return await _customerRepository.CustomerUpdate(customerDTO);
        }

        public async Task<GetListDataResponse<CustomerDTO>> GetCustomerList(int index, int count)
        {
            return await _customerRepository.GetCustomerList(index, count);
        }
    }
}
