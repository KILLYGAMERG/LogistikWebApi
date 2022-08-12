using LogistikWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LogistikWebApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Location> Locations { get; set; }
}

