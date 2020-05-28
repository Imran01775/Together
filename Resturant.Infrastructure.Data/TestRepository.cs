using Resturant.Domain.Entities;
using Resturant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Together_DB.Context;

namespace Resturant.Infrastructure.Data
{
    public class TestRepository : ITestRepository
    {
        

        private readonly SqlServerContext _sqlServerContext;

        public TestRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<TestModel> Save(TestModel testModel)
        {
            await _sqlServerContext.TestModel.AddAsync(testModel);
            await _sqlServerContext.SaveChangesAsync();
            return null;
        }
    }
}
