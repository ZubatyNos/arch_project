using ArchProject.Data;
using ArchProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchProject.Repositories;

public class CartEntryRepository : ICartEntryRepository
{
    private readonly MyDbContext _dbContext;

    public CartEntryRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<CartEntry> GetAllCartEntries()
    {
        return _dbContext.Cart.Include(c => c.FoodItem).ToList();
    }
    
    public void AddToCart(List<StoreFoodItem> selectFoodItemsOfStore)
    {
        foreach (var storeFoodItem in selectFoodItemsOfStore)
        {
            // if the food item is already in the cart, increase the quantity
            var cartEntry = _dbContext.Cart.FirstOrDefault(c => storeFoodItem.FoodItem != null && c.FoodItemId == storeFoodItem.FoodItem.Id);
            if (cartEntry != null)
            {
                cartEntry.Quantity++;
                continue;
            }
            // if the food item is not in the cart, add it
            cartEntry = new CartEntry()
            {
                FoodItemId = storeFoodItem.FoodItem.Id,
                StoreId = storeFoodItem.StoreId,
                Quantity = 1
            };
            _dbContext.Cart.Add(cartEntry);
        }
        _dbContext.SaveChanges();
    }
}