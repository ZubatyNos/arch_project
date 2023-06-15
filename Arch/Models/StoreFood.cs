using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(StoreId), nameof(FoodId))]
public class StoreFood
{
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }
    [Required]
    public int Price { get; set; }
}