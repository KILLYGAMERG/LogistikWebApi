using LogistikWebApi.Dto;
using LogistikWebApi.Interfaces;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogistikWebApi.Controllers;

public class LocationController : Controller
{
    private readonly ILocationRepository _LocationRepository;

    public LocationController(ILocationRepository LocationRepository)
    {
        _LocationRepository = LocationRepository;
    }

    [HttpGet("locations")]
    public async Task<ActionResult<List<LocationDto>>> HttpGetLocationsFromProduct(string productName)
    {
        return await _LocationRepository.GetLocationsFromProduct(productName);
    }

    [HttpPost("location")]
    public async Task<ActionResult<List<LocationDto>>> HttpAddLocation(Location location)
    {
        return await _LocationRepository.AddLocation(location);
    }

    [HttpPut("location")]
    public async Task<ActionResult<List<LocationDto>>> HttpUpdateLocation(Location request)
    {
        return await _LocationRepository.UpdateLocation(request);
    }

    [HttpDelete("location")]
    public async Task<ActionResult<List<LocationDto>>> HttpDeleteLocation(int Id)
    {
        return await _LocationRepository.DeleteLocation(Id);
    }
}

