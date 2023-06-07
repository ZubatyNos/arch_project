using ArchProject.Services;

namespace ArchProject.Commands;

public class ViewCartCommand : ICommand
{
    private readonly ICartEntryService _cartEntryService;
    public ViewCartCommand(ICartEntryService cartEntryService)
    {
        _cartEntryService = cartEntryService;
    }

    public void Execute()
    {
        var cart = _cartEntryService.GetCart();
        Console.WriteLine($"Cart items({cart.Count}):");
        foreach (var cartEntry in cart)
        {
            Console.WriteLine($"{cartEntry.FoodItem.Name}, {cartEntry.Quantity}pcs");
        }
    }

    public void Undo()
    {
        
    }
    
    public string Description => "View Cart Items";
}