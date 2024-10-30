using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface;
using SuperMarket.Core.Interfaces;
using SuperMarket.Core.Strategies;
using SuperMarket.Core.Structs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperMarket.Core.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly StockAvaliableStrategy _stockAvaliableStrategy;
        private readonly ExpirationDateAvailableStrategy _expirationDateAvailableStrategy;
        public ProductService(IProductRepository productRepository, IMapper mapper, StockAvaliableStrategy stockAvaliableStrategy, ExpirationDateAvailableStrategy expirationDateAvailableStrategy)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _expirationDateAvailableStrategy = expirationDateAvailableStrategy;
            _stockAvaliableStrategy = stockAvaliableStrategy;
        }

        private bool IsProductAvailable(ProductsDTO productsDTO)
        {
            bool isExpirationAvailable = _expirationDateAvailableStrategy.IsAvailable(productsDTO);
            bool isStockAvailable = _stockAvaliableStrategy.IsAvailable(productsDTO);
            return isExpirationAvailable && isStockAvailable;
        }

        public async Task<ServiceResult<ProductsDTO>> AddProductAsync(ProductsDTO productsDTO)
        {
            try {
                if (productsDTO == null)
                {
                    return ServiceResult<ProductsDTO>.Error("Products Canno't be Empty!");
                }

                var productEntity = _mapper.Map<Products>(productsDTO);
                var result = await _productRepository.AddProductsAsync(productEntity);
                var createdProductDTO = _mapper.Map<ProductsDTO>(result);
                return createdProductDTO;
            } catch (Exception ex)
            {
                return  ServiceResult<ProductsDTO>.Exception(ex);
            }
        }
        public async Task<List<ProductsDTO>> GetAllProductsAsync()
        {
            var getAllProducts = await _productRepository.GetAllProductsAsync();
            if (getAllProducts == null)
            {
                throw new ArgumentNullException("Product Not Found");
            }
            return getAllProducts;
        }

        public async Task<ServiceResult<ProductsDTO>> GetProcutsByIDAsync(long id)
        {
            try {
                var productsByID = await _productRepository.GetProductsByIDAsync(id);
                if (productsByID == null)
                {
                    return ServiceResult<ProductsDTO>.Error("Product Not Found");
                }

                if (!IsProductAvailable(productsByID))
                {
                    return ServiceResult<ProductsDTO>.Error("Product Not Available in Stock");
                }

                var productDTO = _mapper.Map<ProductsDTO>(productsByID);
                return ServiceResult<ProductsDTO>.Success(productDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductsDTO>.Exception(ex);
            }
        }

        public async  Task<ServiceResult<ProductsDTO>> updateProductsByIDAsync(long id, ProductsDTO productsDTO)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductsByIDAsync(id);
                if (existingProduct == null)
                {
                    return ServiceResult<ProductsDTO>.Error("Product Not Found"); 
                }
                var updateAsync = await _productRepository.updateProductsByIDAsync(id, productsDTO);
                var updatedProduct = _mapper.Map<ProductsDTO>(updateAsync);
                return ServiceResult<ProductsDTO>.Success(updatedProduct);
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductsDTO>.Exception(ex);
            }
        }

        public async Task<ServiceResult<ProductsDTO>> DeleteByIDAsync(long id)
        {
            try { 
            var productById = await _productRepository.GetProductsByIDAsync(id);
            if(productById == null)
            {
                return ServiceResult<ProductsDTO>.Error("Product Not Found");
            }
            var deleteProductByID = await _productRepository.DeleteProductsByIDAsync(productById.ProductID);
            var deletedObject = _mapper.Map<ProductsDTO>(deleteProductByID);
            return ServiceResult<ProductsDTO>.Success(deletedObject);
            }catch(Exception ex)
            {
                return ServiceResult<ProductsDTO>.Exception(ex);
            }
        }

        public async Task<ServiceResult<ProductsDTO>> DeleteAllProducts()
        {
            try
            {
                var allProducts = await _productRepository.DeleteAllProducts();
                if (allProducts == null)
                {
                    return ServiceResult<ProductsDTO>.Error("Product Not Found");
                }
                var deleted = _mapper.Map<ProductsDTO>(allProducts);
                return ServiceResult<ProductsDTO>.Success(deleted);
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductsDTO>.Exception(ex);
            }

        }
    }
}
