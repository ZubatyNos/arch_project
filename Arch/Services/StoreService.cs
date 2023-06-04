using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public List<Store> GetAllStores()
    {
        return _storeRepository.GetAllStores();
    }
}