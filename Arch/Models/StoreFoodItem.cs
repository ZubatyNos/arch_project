using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(StoreId), nameof(FoodItemId))]
public class StoreFoodItem
{
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int FoodItemId { get; set; }
    public FoodItem FoodItem { get; set; }
    public decimal Price { get; set; }
    public List<Order> Orders { get; set; } = new();
}