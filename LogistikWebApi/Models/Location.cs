namespace LogistikWebApi.Models;

public class Location
{
    public List<Shelf> Shelves { get; set; } = new List<Shelf>();

    public string Street { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;


    public int Id { get; set; }
    public int StreetNumber { get; set; }
    public int Postcode { get; set; }
}

