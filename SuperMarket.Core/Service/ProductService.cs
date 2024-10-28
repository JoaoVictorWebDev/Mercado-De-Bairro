using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Exceptions;
using SuperMarket.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace SuperMarket.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductsDTO> AddProductAsync(ProductsDTO productsDTO)
        {
            if (productsDTO == null)
            {
                throw new ResourceNotFoundException("Product data cannot be null.");
            }

            var productEntity = _mapper.Map<Products>(productsDTO);
            await _productRepository.AddProductsAsync(productEntity);
            return _mapper.Map<ProductsDTO>(productEntity);
        }
    }
}
