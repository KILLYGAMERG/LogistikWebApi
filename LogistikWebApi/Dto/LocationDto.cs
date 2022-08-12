using LogistikWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LogistikWebApi.Dto;

public class LocationDto
{
    public static LocationDto FromLocation(Location location) 
    {
        var locationDto = new LocationDto() 
        {
            Id = location.Id,
            Street = location.Street,
            State = location.State,
            Country = location.Country,
            StreetNumber = location.StreetNumber,
            Postcode = location.Postcode,
            UnitsStored = location.UnitsStored,
            FK_Product = location.FK_Product,
        };
        return locationDto;
    }

    [Required]
    public int Id { get; set; }

    public string Street { get; set; } = string.Empty;

    [Required]
    public string State { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;

    public int StreetNumber { get; set; }
    public int Postcode { get; set; }

    public int UnitsStored { get; set; }

    [Required]
    public Guid FK_Product { get; set; }
}

