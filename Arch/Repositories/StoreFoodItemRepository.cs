using ArchProject.Data;
using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext.StoreFoodItem
            .Where(x => x.StoreId == storeId)
            .Include(sf => sf.FoodItem)
            .ToList();
    }
}