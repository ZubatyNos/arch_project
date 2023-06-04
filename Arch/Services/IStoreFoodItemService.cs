using ArchProject.Models;

namespace ArchProject.Services;

public interface IStoreFoodItemService
{
    List<StoreFoodItem> GetAllStoreFoodItemsByStoreId(int storeId);
}