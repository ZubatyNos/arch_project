using System.ComponentModel.DataAnnotations;

namespace ArchProject.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public List<StoreFoodItem> StoreFoodItems { get; set; } = new();
}