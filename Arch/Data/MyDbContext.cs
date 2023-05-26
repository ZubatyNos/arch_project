using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Data;

public class MyDbContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Port=5433;Database=postgres;User Id=zubaty;Password=mypass;";
        optionsBuilder.UseNpgsql(connectionString);
    }
}