using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Data;

public class MyDbContext : DbContext
{
    public DbSet<CartEntry> Cart { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<StoreFoodItem> StoreFoodItem { get; set; }
    public DbSet<FoodItem> FoodItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderStoreFoodItem> OrderStoreFoodItem { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Port=5433;Database=postgres;User Id=zubaty;Password=mypass;";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .Property(o => o.Status)
            .HasConversion<int>();
        
        var stores = CreateStoreDtos();
        modelBuilder.Entity<Store>().HasData(stores);
        
        var foodItems = CreateFoodItemDtos();
        modelBuilder.Entity<FoodItem>().HasData(foodItems);
        
        var storeFoodItems = foodItems.Select(foodItem => new StoreFoodItem()
            {
                FoodItemId = foodItem.Id,
                Price = 10 + (10 * foodItem.Id),
                StoreId = stores.First().Id
            })
            .ToList();
        modelBuilder.Entity<StoreFoodItem>()
            .HasKey(sf => new { sf.StoreId, sf.FoodItemId });
        modelBuilder.Entity<StoreFoodItem>()
            .HasData(storeFoodItems);
    }

    private List<FoodItem> CreateFoodItemDtos()
    {
        return new List<FoodItem>
        {
            new()
            {
                Id = 1,
                Name = "Molotov burger",
                Description = "Burger with a kick"
            },
            new FoodItem
            {
                Id = 2,
                Name = "Vegan burger",
                Description = "Lame burger"
            },
            new FoodItem
            {
                Id = 3,
                Name = "Fries",
                Description = "Just fries, man"
            },
            new FoodItem
            {
                Id = 4,
                Name = "Coke",
                Description = ":)))"
            },
            new FoodItem
            {
                Id = 5,
                Name = "Hasbulla burger",
                Description = "Best one"
            }
        };
    }

    private List<Store> CreateStoreDtos()
    {
        return new List<Store>
        {
            new()
            {
                Id = 1,
                Name = "Hipstersky store",
                OpeningTime = new TimeSpan(16, 30, 0),
                ClosingTime = new TimeSpan(20, 0, 0)
            },
            new()
            {
                Id = 2,
                Name = "Tuniaky",
                OpeningTime = new TimeSpan(0, 0, 0),
                ClosingTime = new TimeSpan(23, 0, 0)
            }
        };

    }
}