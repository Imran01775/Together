using Microsoft.AspNetCore.Authentication.JwtBearer;
using Resturant.Domain.Entities;
using Resturant.Domain.Interfaces;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class TestService : ITestService
    {
        private ITestRepository _itestRepository = null;
        public TestService(ITestRepository itestRepository)
        {
           
            _itestRepository = itestRepository;
        }
        public async Task<TestModel> Save(TestModel testModel)
        {
            return await _itestRepository.Save(testModel);
        }
    }
}
