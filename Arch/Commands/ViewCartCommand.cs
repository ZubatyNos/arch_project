using ArchProject.Services;

namespace ArchProject.Commands;

public class ViewCartCommand : ICommand
{
    private readonly ICartService _cartService;
    public ViewCartCommand(ICartService cartService)
    {
        this._cartService = cartService;
    }

    public void Execute()
    {
        // View cart using the CartService
        Console.Write("Please enter the id of the cart you want to view:");
        var id = int.Parse(Console.ReadLine() ?? string.Empty);
        var cart = _cartService.GetCartById(id);
        if (cart != null)
        {
            Console.WriteLine("........");
            Console.WriteLine($"Cart id: {cart.Id}, Quantity: {cart.Quantity}, MenuItemId: {cart.MenuItemId}");
        }
    }

    public void Undo()
    {
        
    }
    
    public string Description => "View Cart (input: id)";
}