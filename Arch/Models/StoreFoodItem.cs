using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArchProject.Models;

[PrimaryKey("StoreId", "ItemId")]
public class StoreFoodItem
{
    public int StoreId { get; set; }
    public Store? Store { get; set; }
    public int ItemId { get; set; }
    public FoodItem? FoodItem { get; set; }
    public decimal Price { get; set; }
}