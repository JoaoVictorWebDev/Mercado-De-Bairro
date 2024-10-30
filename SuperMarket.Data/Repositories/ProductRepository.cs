using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interfaces;
using SuperMarket.Core.Structs;
using SuperMarket.Data.Contexts;

namespace SuperMarket.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsDTO> AddProductsAsync(Products products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products), "Product cannot be null.");
            }

            var productsEntry = await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
            var productsDTO = _mapper.Map<ProductsDTO>(productsEntry.Entity);
            return productsDTO;
        }

        public async Task<List<ProductsDTO>> GetAllProductsAsync()
        {
            var productsAsync = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductsDTO>>(productsAsync);
        }

        public async Task<ProductsDTO> updateProductsByIDAsync(long id, ProductsDTO productsDTO)
        {
            var ProductToUpdate = await _context.Products
                .FirstOrDefaultAsync(e => e.ProductID == id);
            ProductToUpdate.ProductName = productsDTO.ProductName;
            ProductToUpdate.Quantity = productsDTO.Quantity;
            ProductToUpdate.Price = productsDTO.Price;
            ProductToUpdate.Supplier = productsDTO.Supplier;
            ProductToUpdate.ProductCategory = productsDTO.ProductCategory;
            ProductToUpdate.Discount = productsDTO.Discount;
            ProductToUpdate.Description = productsDTO.Description;
            ProductToUpdate.ExpirationDate = productsDTO.ExpirationDate;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductsDTO>(ProductToUpdate);
        }

        public async Task<ProductsDTO> GetProductsByIDAsync(long id)
        {
            var productsByID = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            return _mapper.Map<ProductsDTO>(productsByID);
        }

        public async Task<ProductsDTO> DeleteProductsByIDAsync(long id)
        {
            var productToDelete = await _context.Products
                .FirstOrDefaultAsync(e => e.ProductID == id);
            _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductsDTO>(productToDelete);
        }

        public async Task<List<ProductsDTO>> DeleteAllProducts()
        {
            var allProducts = await _context.Products.ToListAsync();
            _context.Products.RemoveRange(allProducts);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<ProductsDTO>>(allProducts);
        }
    }
}
