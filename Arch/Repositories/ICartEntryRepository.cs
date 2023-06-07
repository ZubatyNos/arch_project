using ArchProject.Models;

namespace ArchProject.Repositories;

public interface ICartEntryRepository
{
    List<CartEntry> GetAllCartEntries();
    void AddToCart(List<StoreFoodItem> selectFoodItemsOfStore);
}