using LogistikWebApi.Data;
using LogistikWebApi.Dto;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikWebApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    private readonly IGroupRepository _groupRepository;

    public ProductRepository(DataContext context, IGroupRepository groupRepository)
    {
        _context = context;
        _groupRepository = groupRepository;
    }

    public async Task<ActionResult<List<ProductDto>>> AddProduct(Product product)
    {

        _context.Products.Add(product);
        await save();
        return await _context.Products.Select(x => ProductDto.FromProduct(x)).ToListAsync();

    }

    public async Task<ActionResult<List<ProductDto>>> DeleteProduct(Guid Id)
    {
        var Product = await _context.Products.FindAsync(Id);
        if (Product == null)
        {
            throw new Exception();
        }
        _context.Products.Remove(Product);
        await save();
        return await _context.Products.Select(x => ProductDto.FromProduct(x)).ToListAsync(); 
    }

    public async Task<ActionResult<List<ProductDto>>> GetProductsFromGroup(string name)
    {
        var myGroup = await _groupRepository.GetGroupByName(name);

        var myProductsList = await _context.Products.Where(x => x.FK_groupId == myGroup.Value.Id).Select(x => ProductDto.FromProduct(x)).ToListAsync();
    
        return myProductsList;

    }

    public async Task<ActionResult<ProductDto>> GetProductByName(string name)
    {
        var Product = await _context.Products.FirstAsync(g => g.Name == name);
        if (Product == null) 
        {
            throw new Exception();
        }
        return await _context.Products.Where(x => x.Id == Product.Id).Select(x => ProductDto.FromProduct(x)).SingleAsync();
    }

    public async Task save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ActionResult<ProductDto>> UpdateProduct(Product request)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null)
        {
            throw new Exception();
        }
        product.Name = request.Name;
        product.InWarehouseSince = request.InWarehouseSince;

        await save();

        return await GetProductByName(request.Name);
    }
}

