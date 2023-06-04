using ArchProject.Models;

namespace ArchProject.Repositories;

public interface IStoreRepository 
{
  // get all stores
  List<Store> GetAllStores();
}