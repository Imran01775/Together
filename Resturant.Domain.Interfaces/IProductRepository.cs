using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;

namespace Resturant.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> ProductDelete(ProductDTO productDTO);
        Task<ProductDTO> ProductEntryUpdate(ProductDTO productDTO);
        Task<GetListDataResponse<ProductDTO>> GetProductList(int index, int count);
    }
}
