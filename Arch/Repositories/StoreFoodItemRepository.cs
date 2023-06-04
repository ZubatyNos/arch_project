using ArchProject.Data;
using ArchProject.Models;

namespace ArchProject.Repositories;

public class StoreFoodItemRepository : IStoreFoodItemRepository
{
    private readonly MyDbContext _dbContext;

    public StoreFoodItemRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<StoreFoodItem> GetAllStoreFoodItemsByStoreId(int storeId)
    {
        using var context = new MyDbContext();
        return context.StoreFoodItem.Where(x => x.StoreId == storeId).ToList();
    }
}