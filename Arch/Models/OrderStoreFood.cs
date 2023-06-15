using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(OrderId), nameof(StoreId), nameof(FoodId))]
public class OrderStoreFood
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }
    [Required]
    public int Quantity { get; set; }
}