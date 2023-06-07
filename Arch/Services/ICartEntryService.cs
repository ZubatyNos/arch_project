using ArchProject.Models;

namespace ArchProject.Services;

public interface ICartEntryService
{
    List<CartEntry> GetCart();
    void AddToCart(List<StoreFoodItem> selectFoodItemsOfStore);
}