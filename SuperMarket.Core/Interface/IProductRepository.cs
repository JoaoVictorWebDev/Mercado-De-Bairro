using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Entities;

namespace SuperMarket.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductsDTO> AddProductsAsync(Products Product);
        //Task<List<ProductsDTO>> GetAllProductsAsync();
        //Task<Products> GetProductsByIDAsync(long id);
        //Task<ProductsDTO> updateProductsByIDAsync(long id, Products Products);
        //Task<ProductsDTO> DeleteProductsByIDAsync(long id);
        //Task<List<ProductsDTO>> DeleAllProducts();
    }
}
