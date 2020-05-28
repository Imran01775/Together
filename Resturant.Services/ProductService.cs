using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using Resturant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetListDataResponse<ProductDTO>> GetProductList(int index, int count)
        {
            return await _productRepository.GetProductList(index,count);
        }

        public async Task<ProductDTO> ProductDelete(ProductDTO productDTO)
        {
            return await _productRepository.ProductDelete(productDTO);
        }

        public async Task<ProductDTO> ProductEntryUpdate(ProductDTO productDTO)
        {
            return await _productRepository.ProductEntryUpdate(productDTO);
        }
    }
}
