namespace LogistikWebApi.Models;

public class Product
{
    public Location Location { get; set; } = new Location();
    public Group Group { get; set; } = new Group();
    public Shelf Shelf { get; set; } = new Shelf();
    
    public DateTime InWarehouseSince { get; set; }

    public int Id { get; set; }
    public int Stückzahl { get; set; }
}

