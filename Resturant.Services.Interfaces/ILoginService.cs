using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginCustomer(LoginDataModel loginDataModel);
        Task<LoginResponse> LoginEmployee(LoginDataModel loginDataModel);
    }
}
