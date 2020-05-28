using Resturant.Domain.Entities.Entities;
using Resturant.Domain.Entities.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Interfaces
{
    public interface IJwtSecurityService
    {
        LoginResponse GetTokenCustomer(Customer response);
        LoginResponse GetTokenEmployee(Employee response);
    }
}
