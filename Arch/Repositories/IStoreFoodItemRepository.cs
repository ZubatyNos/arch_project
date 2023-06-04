using ArchProject.Models;

namespace ArchProject.Repositories;

public interface IStoreFoodItemRepository
{
    List<StoreFoodItem> GetAllStoreFoodItemsByStoreId(int storeId);
}