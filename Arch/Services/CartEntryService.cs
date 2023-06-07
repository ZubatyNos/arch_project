using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Services;

public class CartEntryService : ICartEntryService
{
    private readonly ICartEntryRepository _cartEntryRepository; 
    
    public CartEntryService(ICartEntryRepository cartEntryRepository)
    {
        _cartEntryRepository = cartEntryRepository;
    }
    
    public List<CartEntry> GetCart()
    {
        return _cartEntryRepository.GetAllCartEntries();
    }

    public void AddToCart(List<StoreFoodItem> selectFoodItemsOfStore)
    {
        _cartEntryRepository.AddToCart(selectFoodItemsOfStore);
    }
}