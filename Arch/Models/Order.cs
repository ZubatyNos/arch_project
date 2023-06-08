using System.ComponentModel.DataAnnotations;
using ArchProject.Enums;

namespace ArchProject.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}