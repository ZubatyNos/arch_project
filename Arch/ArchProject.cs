using ArchProject.Data;
using ArchProject.Repositories;
using ArchProject.Services;

namespace ArchProject;

class Arch
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the CLI Application!");
        // Console.WriteLine("Please enter the number corresponding to the command you want to execute:");
        // Console.WriteLine("1. Place Order");
        // Console.WriteLine("2. Cancel Order");
        // Console.WriteLine("3. View Menu");
        // Console.WriteLine("4. Add to Cart");
        // Console.WriteLine("5. Remove from Cart");
        // Console.WriteLine("6. View Cart");
        // Console.WriteLine("7. Customize Menu Item");
        // Console.WriteLine("8. Checkout");

        using var dbContext = new MyDbContext();
        var cartRepository = new CartRepository(dbContext);
        var cartService = new CartService(cartRepository);
            
        var cart = cartService.GetCartById(1);
        Console.WriteLine(cart != null ? $"Cart with id {cart.Id}" : "Cart not found.");
    }
}