using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArchProject.Enums;

namespace ArchProject.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
    public List<Food> Foods { get; set; }
}