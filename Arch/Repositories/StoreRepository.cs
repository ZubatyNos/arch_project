using ArchProject.Data;
using ArchProject.Models;

namespace ArchProject.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly MyDbContext _dbContext;
    
    public StoreRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Store> GetAllStores()
    {
        using var context = new MyDbContext();
        return context.Store.ToList();
    }
}