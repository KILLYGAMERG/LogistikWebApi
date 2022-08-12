using LogistikWebApi.Dto;
using LogistikWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LogistikWebApi.Interfaces;

public interface ILocationRepository
{
    public Task<ActionResult<List<LocationDto>>> GetLocationsFromProduct(string name);
    public Task<ActionResult<List<LocationDto>>> AddLocation(Location location);
    public Task<ActionResult<List<LocationDto>>> UpdateLocation(Location request);
    public Task<ActionResult<List<LocationDto>>> DeleteLocation(int Id);
    public Task save();
}

