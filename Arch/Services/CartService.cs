using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository; 
    
    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Cart? GetCartById(int id)
    {
        return _cartRepository.GetCartById(id);
    }
}