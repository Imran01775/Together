using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDTO> EmployeeDelete(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> EmployeeEntry(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> EmployeeUpdate(EmployeeDTO employeeDTO);
        Task<GetListDataResponse<EmployeeDTO>> GetEmployeeList(int index, int count);
    }
    public interface IEmployeeCheckExistsRepository
    {
        Task<EmployeeDTO> EmployeeCheckExists(EmployeeDTO employeeDTO);
    }
}
