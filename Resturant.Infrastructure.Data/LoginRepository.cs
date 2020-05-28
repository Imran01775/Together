using Resturant.Domain.Entities;
using Resturant.Domain.Entities.Entities;
using Resturant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public LoginRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public Customer LoginCustomer(LoginDataModel loginDataModel)
        {
            var response = _sqlServerContext.Customer.Where(c => c.Mobile == loginDataModel.Mobile && c.Password == loginDataModel.Password).FirstOrDefault();
            return  response;
        }

        public  Employee LoginEmployee(LoginDataModel loginDataModel)
        {
            var response = _sqlServerContext.Employee.Where(c => c.Mobile == loginDataModel.Mobile && c.Password == loginDataModel.Password).FirstOrDefault();
            return response;
        }
    }
}
