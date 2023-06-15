using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Commands;

public class ViewCartCommand : ICommand
{
    private readonly IGenericRepository<CartEntry> _cartEntryRepository;
    public ViewCartCommand(IGenericRepository<CartEntry> cartEntryRepository)
    {
        _cartEntryRepository = cartEntryRepository;
    }

    public void Execute()
    {
        var cart = _cartEntryRepository.GetAll(c => c.Food).ToArray();
        Console.WriteLine($"Cart items({cart.Length}):");
        foreach (var cartEntry in cart)
        {
            Console.WriteLine($"{cartEntry.Food.Name}, {cartEntry.Quantity}pcs");
        }
    }

    public void Undo()
    {
        
    }
    
    public string Description => "View Cart Items";
}