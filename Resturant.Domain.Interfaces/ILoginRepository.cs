using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities;
using Resturant.Domain.Entities.Entities;

namespace Resturant.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Customer LoginCustomer(LoginDataModel loginDataModel);
        Employee LoginEmployee(LoginDataModel loginDataModel);
    }
}
