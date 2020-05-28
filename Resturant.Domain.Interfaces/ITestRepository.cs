using Resturant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain.Interfaces
{
    public interface ITestRepository
    {
        Task<TestModel> Save(TestModel testModel);
    }
}
