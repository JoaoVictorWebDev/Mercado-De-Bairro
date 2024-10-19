using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Data.Contexts;

namespace SuperMarket.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public ProductController(ApplicationDBContext context)
    {
        _context = context;
    }
    [HttpGet("/allProducts")]
    public IActionResult GetAll() 
    {
        var products = _context.Products.ToList();
        var productsDTO = products.Select(products => new ProductsDTO()
        {
            ProductID = products.ProductID,
            ProductCategory = products.ProductCategory,
            ProductName = products.ProductName,
            Supplier = products.Supplier,
            ExpirationDate = products.ExpirationDate,
        }).ToList();
        return Ok(new { Message = "Here's your List!", Data = productsDTO });
    }

    [HttpGet("/getProductById{id}")]

    public async Task<IActionResult> GetById(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if(product == null)
        {
            return NotFound(new { Message = "Product Not Found!" });
        }
        var productDTO = new ProductsDTO
        {
            ProductID = product.ProductID,
            ProductName = product.ProductName,
            ProductCategory = product.ProductCategory,
            ExpirationDate = product.ExpirationDate,
            Supplier = product.Supplier
        };
        return Ok(new { Message = "Product Found", Data = productDTO });
    }

    [HttpDelete("/deleteById{id}")]
    public async Task<IActionResult> DeleteById(long id)
    {
        Products products = _context.Products.Find(id);
        _context.Products.Remove(products);
        _context.SaveChanges();
        return Ok(new { Message = "Product Has been Deleted!" , Data = products});
    }

    [HttpPost("/addProduct")]
    public IActionResult AddProduct([FromBody] ProductsDTO productsDTO)
    {
        var products = new Products
        {
            ProductName = productsDTO.ProductName,
            ProductCategory = productsDTO.ProductCategory,
            Supplier = productsDTO.Supplier,
            ExpirationDate = productsDTO.ExpirationDate
        };

        _context.Products.Add(products);
        _context.SaveChanges();

        var insertproductsDTO = new ProductsDTO
        {         
            ProductID = products.ProductID,
            ProductCategory = products.ProductCategory,
            ProductName = products.ProductName,
            Supplier = products.Supplier,
            ExpirationDate = products.ExpirationDate
        };

        return Created("/api/products" + products.ProductID, new { Message = "Product Created!", Data = insertproductsDTO });
    }
}
