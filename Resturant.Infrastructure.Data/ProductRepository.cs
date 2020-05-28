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
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public ProductRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentException(nameof(sqlServerContext));
        }

        public async Task<GetListDataResponse<ProductDTO>> GetProductList(int index, int count)
        {
            var response = new GetListDataResponse<ProductDTO>();
            response.Model = await (from product in _sqlServerContext.Product

                                    select new ProductDTO
                                    {
                                        CompanyPercentage = product.CompanyPercentage
                                    }
                                    ).ToListAsync();
            return response;
        }

        public async Task<ProductDTO> ProductDelete(ProductDTO productDTO)
        {
            var dataObject = productDTO as Product;
            _sqlServerContext.Remove<Product>(dataObject);
            await _sqlServerContext.SaveChangesAsync();
            return productDTO;
        }

        public async Task<ProductDTO> ProductEntryUpdate(ProductDTO productDTO)
        {
            var dataObject = productDTO as Product;
            if (productDTO.ProductId == 0)
            {
                await _sqlServerContext.AddAsync<Product>(dataObject);
            }
            else
            {
                _sqlServerContext.Update<Product>(dataObject);
            }
            await _sqlServerContext.SaveChangesAsync();
            return productDTO;
        }
    }
}
