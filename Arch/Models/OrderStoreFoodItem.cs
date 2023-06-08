using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(OrderId), nameof(StoreId), nameof(FoodItemId))]
public class OrderStoreFoodItem
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int StoreId { get; set; }
    public Store? Store { get; set; }
    public int FoodItemId { get; set; }
    public FoodItem? FoodItem { get; set; }
    public int Quantity { get; set; }
}