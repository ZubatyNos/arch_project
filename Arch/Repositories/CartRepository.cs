using ArchProject.Data;
using ArchProject.Models;

namespace ArchProject.Repositories;

public class CartRepository : ICartRepository
{
    private readonly MyDbContext _dbContext;

    public CartRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Cart? GetCartById(int id)
    {
        return _dbContext.Carts.Find(id);
    }
}