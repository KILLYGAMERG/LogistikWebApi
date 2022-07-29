namespace LogistikWebApi.Models;

public class Shelf
{
    public List<Product> Products { get; set; } = new List<Product>();
    
    public int Id { get; set; }
    public int AisleNumber { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
}

