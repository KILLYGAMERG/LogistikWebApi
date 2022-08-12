namespace LogistikWebApi.Models;

public class Location
{
    public int Id { get; set; }

    public string Street { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
 
    public int StreetNumber { get; set; }
    public int Postcode { get; set; }

    public int UnitsStored { get; set; }

    public Guid FK_Product { get; set; }
}

