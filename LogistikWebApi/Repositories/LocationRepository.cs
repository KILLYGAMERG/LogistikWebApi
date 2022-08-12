using LogistikWebApi.Data;
using LogistikWebApi.Dto;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikWebApi.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly DataContext _context;
    private readonly IProductRepository _productRepository;

    public LocationRepository(DataContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<ActionResult<List<LocationDto>>> AddLocation(Location location)
    {
        _context.Locations.Add(location);
        await save();

        return await _context.Locations.Select(x => LocationDto.FromLocation(x)).ToListAsync();
    }

    public async Task<ActionResult<List<LocationDto>>> DeleteLocation(int Id)
    {
        var Location = await _context.Locations.FindAsync(Id);
        if (Location == null)
        {
            throw new Exception();
        }
        _context.Locations.Remove(Location);
        await save();
        return await _context.Locations.Select(x => LocationDto.FromLocation(x)).ToListAsync();
    }

    public async Task<ActionResult<List<LocationDto>>> GetLocationsFromProduct(string name)
    {
        var myProduct = await _productRepository.GetProductByName(name);

        var myLocationsList = await _context.Locations.Where(x => x.FK_Product == myProduct.Value.Id).Select(x => LocationDto.FromLocation(x) ).ToListAsync();

        return myLocationsList;
    }

    public async Task save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ActionResult<List<LocationDto>>> UpdateLocation(Location request)
    {
        var location = await _context.Locations.FindAsync(request.Id);
        if (location == null)
        {
            throw new Exception();
        }
        location.Street = request.Street;
        location.StreetNumber = request.StreetNumber;
        location.Postcode = request.Postcode;
        location.State = request.State;
        location.Country = request.Country;
        location.UnitsStored = request.UnitsStored;

        await save();

        return await _context.Locations.Select(x => LocationDto.FromLocation(x)).ToListAsync();
    }
}

