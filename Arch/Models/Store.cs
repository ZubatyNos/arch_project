using System.ComponentModel.DataAnnotations;

namespace ArchProject.Models;

public class Store
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public List<Food> Foods { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    
    public bool IsOpen()
    {
        var now = DateTime.Now.TimeOfDay;
        return now >= OpeningTime && now <= ClosingTime;
    }
}