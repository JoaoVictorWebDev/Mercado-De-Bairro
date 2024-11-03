using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface.Service;
using SuperMarket.Core.Service;
using SuperMarket.Data.Contexts;
using System.Diagnostics.CodeAnalysis;

namespace SuperMarket.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    [Authorize(Roles = "admin")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("/allProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(new { Message = "Here's your List!", Data = result});
    }
    [Authorize]
    [HttpGet("/getProductById{id}")]

    public async Task<IActionResult> GetById(long id)
    {
        var product = await _productService.GetProcutsByIDAsync(id);
        return Ok(new { Message = "Product Found", Data = product });
    }
    [Authorize]
    [HttpDelete("/deleteById{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        var productsByID = _productService.DeleteByIDAsync(id);
        return Ok(new { Message = "Product Has been Deleted!", Data = productsByID });
    }
    [Authorize]
    [HttpDelete("/deleteAll")]
    public async Task<IActionResult> DeleteAll()
    {
        var result = _productService.DeleteAllProducts();
        return Ok(new { Message = "All Products Has been Deleted!", Data = result });
    }
    [Authorize]
    [HttpPost("/addProduct")]
    public async Task<IActionResult> AddProduct([FromBody] ProductsDTO productsDTO)
    {
        await _productService.AddProductAsync(productsDTO);
        return Created("/api/products" + productsDTO, new { Message = "Product Created!", Data = productsDTO });
    }

    [HttpPut("/updateProductById{id}")]
    public async Task<IActionResult> UpdateByID([FromBody] ProductsDTO productsDTO, long id)
    {
        var result = await _productService.updateProductsByIDAsync(id, productsDTO);
        return Ok(new { Message = "Product has been edited!", Data = result});
    }
}
