using LogistikWebApi.Dto;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogistikWebApi.Interfaces;

public interface IProductRepository
{
    public Task<ActionResult<List<ProductDto>>> GetProductsFromGroup(string name);
    public Task<ActionResult<ProductDto>> GetProductByName(string name);
    public Task<ActionResult<List<ProductDto>>> AddProduct(Product product);
    public Task<ActionResult<ProductDto>> UpdateProduct(Product request);
    public Task<ActionResult<List<ProductDto>>> DeleteProduct(Guid Id);
    public Task save();
}

