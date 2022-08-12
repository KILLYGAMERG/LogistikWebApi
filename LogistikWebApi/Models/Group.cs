using LogistikWebApi.Interfaces;

namespace LogistikWebApi.Models;

public class Group
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public int ValueAddedTaxes { get; set; }
    public string Name { get; set; } = string.Empty;
}

