using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(StoreId), nameof(FoodItemId))]
public class CartEntry
{
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int FoodItemId { get; set; }
    public FoodItem FoodItem { get; set; }
    public int Quantity { get; set; }
    
}