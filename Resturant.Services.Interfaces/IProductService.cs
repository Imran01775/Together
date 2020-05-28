using Resturant.Domain.Entities.DTOs;
using Resturant.Domain.Entities.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> ProductEntryUpdate(ProductDTO productDTO);
        Task<ProductDTO> ProductDelete(ProductDTO productDTO);
        Task<GetListDataResponse<ProductDTO>> GetProductList(int index, int count);
    }
}
