using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Structs;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductsDTO> AddProductsAsync(Products Product);
        Task<List<ProductsDTO>> GetAllProductsAsync();
        Task<ProductsDTO> GetProductsByIDAsync(long id);
        Task <ProductsDTO> updateProductsByIDAsync(long id, ProductsDTO Products);
        Task <ProductsDTO> DeleteProductsByIDAsync(long id);
        Task<List<ProductsDTO>> DeleteAllProducts();
    }
}
