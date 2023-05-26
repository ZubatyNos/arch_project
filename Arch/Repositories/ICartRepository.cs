using ArchProject.Models;

namespace ArchProject.Repositories;

public interface ICartRepository
{
    Cart? GetCartById(int id);
    
}