using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Data;

public class MyDbContext : DbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<StoreFoodItem> StoreFoodItem { get; set; }
    public DbSet<FoodItem> FoodItem { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Port=5433;Database=postgres;User Id=zubaty;Password=mypass;";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>().HasData(
            new Store
            {
                Id = 1,
                Name = "Hipstersky store",
                OpeningTime = new TimeSpan(16, 30, 0),
                ClosingTime = new TimeSpan(20, 0, 0)
            }
        );
        
        modelBuilder.Entity<StoreFoodItem>().HasData(
            new StoreFoodItem()
            {
                FoodItem = null,
                ItemId = 1,
                Price = 10,
                Store = null,
                StoreId = 1
            }
        );
    }
}