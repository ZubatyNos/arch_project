namespace ArchProject.Models;
using System.ComponentModel.DataAnnotations;

public class Cart
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int MenuItemId { get; set; }
    
}