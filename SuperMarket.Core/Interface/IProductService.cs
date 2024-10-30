using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Structs;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<ProductsDTO>> AddProductAsync(ProductsDTO Products);
        Task <List<ProductsDTO>> GetAllProductsAsync();
        Task<ServiceResult<ProductsDTO>> GetProcutsByIDAsync(long id);
        Task<ServiceResult<ProductsDTO>> updateProductsByIDAsync(long id, ProductsDTO productsDTO);
        Task <ServiceResult<ProductsDTO>> DeleteByIDAsync(long id);
        Task<ServiceResult<ProductsDTO>> DeleteAllProducts();
    }
}
