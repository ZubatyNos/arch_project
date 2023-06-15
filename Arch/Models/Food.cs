using System.ComponentModel.DataAnnotations;

namespace ArchProject.Models;

public class Food
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}