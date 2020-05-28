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
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{

    public class EmployeeRepository : IEmployeeRepository, IEmployeeCheckExistsRepository
    {

        private readonly SqlServerContext _sqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {

            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public async Task<EmployeeDTO> EmployeeCheckExists(EmployeeDTO employeeDTO)
        {
            var response = await _sqlServerContext.Employee.Where(v => v.Mobile == employeeDTO.Mobile).FirstOrDefaultAsync();


            if (response != null)
                return employeeDTO;
            else
                return null;


        }

        public async Task<EmployeeDTO> EmployeeDelete(EmployeeDTO employeeDTO)
        {
            var dataObject = employeeDTO as Employee;
            _sqlServerContext.Remove<Employee>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return employeeDTO;
        }

        public async Task<EmployeeDTO> EmployeeEntry(EmployeeDTO employeeDTO)
        {
            var dataObject = employeeDTO as Employee;
            await _sqlServerContext.AddAsync<Employee>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return employeeDTO;
        }

        public async Task<EmployeeDTO> EmployeeUpdate(EmployeeDTO employeeDTO)
        {
            var dataObject = employeeDTO as Employee;
            _sqlServerContext.Update<Employee>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return employeeDTO;
        }

        public async Task<GetListDataResponse<EmployeeDTO>> GetEmployeeList(int index, int count)
        {

            var response = new GetListDataResponse<EmployeeDTO>();
            response.TotalCount = 10;
            response.Model = (from employee in _sqlServerContext.Employee

                              select new EmployeeDTO
                              {
                                  Name = employee.Name
                              }).ToList();
            return response;
        }
    }
}
