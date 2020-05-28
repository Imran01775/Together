using Resturant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Interfaces
{
    public interface ITestService
    {
        Task<TestModel> Save(TestModel testModel);
    }
}
