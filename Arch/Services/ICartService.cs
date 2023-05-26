using ArchProject.Models;

namespace ArchProject.Services;

public interface ICartService
{
    Cart? GetCartById(int id);
}