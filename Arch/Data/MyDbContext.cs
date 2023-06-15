using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Data;

public class MyDbContext : DbContext
{
    public DbSet<CartEntry> CartEntry { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Food> Food { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<StoreFood> StoreFood { get; set; }
    public DbSet<OrderStoreFood> OrderStoreFood { get; set; }

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
        
        var foods = CreateFoodItemDtos();
        modelBuilder.Entity<Food>().HasData(foods);
        
        var storeFoods = foods.Select(food => new StoreFood()
            {
                FoodId = food.Id,
                Price = 10 + (10 * food.Id),
                StoreId = stores.First().Id
            })
            .ToList();
        modelBuilder.Entity<StoreFood>()
            .HasKey(sf => new { sf.StoreId, sf.FoodId });
        modelBuilder.Entity<StoreFood>()
            .HasData(storeFoods);
    }

    private List<Food> CreateFoodItemDtos()
    {
        return new List<Food>
        {
            new()
            {
                Id = 1,
                Name = "Molotov burger",
                Description = "Burger with a kick"
            },
            new Food
            {
                Id = 2,
                Name = "Vegan burger",
                Description = "Lame burger"
            },
            new Food
            {
                Id = 3,
                Name = "Fries",
                Description = "Just fries, man"
            },
            new Food
            {
                Id = 4,
                Name = "Coke",
                Description = ":)))"
            },
            new Food
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