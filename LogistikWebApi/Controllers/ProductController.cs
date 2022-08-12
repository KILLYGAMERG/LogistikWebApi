using LogistikWebApi.Dto;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogistikWebApi.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("products")]
    public async Task<ActionResult<List<ProductDto>>> HttpGetProductsFromGroup(string name)
    {
        return await _productRepository.GetProductsFromGroup(name);
    }

    [HttpGet("product")]
    public async Task<ActionResult<ProductDto>> HttpGetProductByName(string name)
    {
        return await _productRepository.GetProductByName(name);
    }

    [HttpPost("product")]
    public async Task<ActionResult<List<ProductDto>>> HttpAddProduct(Product product)
    {
       return await _productRepository.AddProduct(product);
    }

    [HttpPut("product")]
    public async Task<ActionResult<ProductDto>> HttpUpdateProduct(Product request)
    {
        return await _productRepository.UpdateProduct(request);
    }

    [HttpDelete("product")]
    public async Task<ActionResult<List<ProductDto>>> HttpDeleteProduct(Guid Id)
    {
        return await _productRepository.DeleteProduct(Id);
    }
}

