using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Service;
using SuperMarket.Data.Contexts;
using System.Diagnostics.CodeAnalysis;

namespace SuperMarket.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(ProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    //[HttpGet("/allProducts")]
    //public IActionResult GetAllProducts() 
    //{
    //    var products = _context.Products.ToList();
    //    var productsDTO = _mapper.Map<List<ProductsDTO>>(products);
    //    return Ok(new { Message = "Here's your List!", Data = productsDTO });
    //}

    //[HttpGet("/getProductById{id}")]

    //public async Task<IActionResult> GetById(long id)
    //{
    //    var product = await _context.Products.FindAsync(id);
    //    if(product == null)
    //    {
    //        return NotFound(new { Message = "Product Not Found!" });
    //    }
    //    var GetProductsByID = _mapper.Map<ProductsDTO>(product);
    //    return Ok(new { Message = "Product Found", Data = GetProductsByID });
    //}

    //[HttpDelete("/deleteById{id}")]
    //public async Task<IActionResult> DeleteById(long id)
    //{
    //    Products products = _context.Products.Find(id);
    //    _context.Products.Remove(products);
    //    _context.SaveChanges();
    //    return Ok(new { Message = "Product Has been Deleted!" , Data = products});
    //}

    //[HttpDelete("/deleteAll")]
    //public async Task<IActionResult> DeleteAll()
    //{
    //    var products = _context.Products.ToList();

    //    if(products.Count == 0)
    //    {
    //        return NotFound(new { Message = "No Products found to delete" });
    //    }

    //    _context.Products.RemoveRange(products);
    //    await _context.SaveChangesAsync();
    //    return Ok(new { Message = "All Records Has been Deleted!" });
    //}
    [HttpPost("/addProduct")]
    public async Task<IActionResult> AddProduct([FromBody] ProductsDTO productsDTO)
    {
        _productService.AddProductAsync(productsDTO);
        return Created("/api/products" + productsDTO, new { Message = "Product Created!", Data = productsDTO });
    }

    //[HttpPut("/updateProductById{id}")]
    //public async Task<IActionResult> UpdateByID ([FromBody] ProductsDTO productsDTO, long id)
    //{
    //    var affectedRows = await _context.Products
    //        .Where(i => i.ProductID == id).
    //        ExecuteUpdateAsync(update => update.
    //                       SetProperty(product => product.ProductName, productsDTO.ProductName)
    //                      .SetProperty(product => product.ProductCategory, productsDTO.ProductCategory)
    //                      .SetProperty(product => product.Supplier, productsDTO.Supplier)
    //                      .SetProperty(product => product.ExpirationDate, productsDTO.ExpirationDate));
                          
    //    if (affectedRows == 0)
    //    {
    //        return NotFound(new { Message = "Product not Found !" });
    //    }
    //    return Ok(new { Message = "Product has been edited!" });
    //}
}
