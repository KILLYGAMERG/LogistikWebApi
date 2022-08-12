namespace LogistikWebApi.Models;

public class Product
{
    
    public DateTime InWarehouseSince { get; set; }

    public Guid Id { get; set; }

    public Guid FK_groupId { get; set; } 

    public string Name { get; set; } = string.Empty;
}

