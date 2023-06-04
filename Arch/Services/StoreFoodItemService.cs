using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Services;

public class StoreFoodItemService : IStoreFoodItemService
{
    private readonly IStoreFoodItemRepository _storeFoodItemRepository;

    public StoreFoodItemService(IStoreFoodItemRepository storeFoodItemRepository)
    {
        _storeFoodItemRepository = storeFoodItemRepository;
    }

    public List<StoreFoodItem> GetAllStoreFoodItemsByStoreId(int storeId)
    {
        return _storeFoodItemRepository.GetAllStoreFoodItemsByStoreId(storeId);
    }
}