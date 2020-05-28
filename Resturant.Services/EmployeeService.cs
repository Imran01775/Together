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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeCheckExistsRepository _employeeCheckExistsRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeCheckExistsRepository employeeCheckExistsRepository)
        {
            _employeeCheckExistsRepository = employeeCheckExistsRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDTO> EmployeeDelete(EmployeeDTO employeeDTO)
        {
            return await _employeeRepository.EmployeeDelete(employeeDTO);
        }

        public async Task<EmployeeDTO> EmployeeEntry(EmployeeDTO employeeDTO)
        {
            var response = await _employeeCheckExistsRepository.EmployeeCheckExists(employeeDTO);

            if (response == null)
                response = await _employeeRepository.EmployeeEntry(employeeDTO);

            return response;
        }

        public async Task<EmployeeDTO> EmployeeUpdate(EmployeeDTO employeeDTO)
        {
            return await _employeeRepository.EmployeeUpdate(employeeDTO);
        }

        public async Task<GetListDataResponse<EmployeeDTO>> GetEmployeeList(int index, int count)
        {
            return await _employeeRepository.GetEmployeeList(index, count);
        }
    }
}
