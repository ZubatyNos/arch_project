using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Commands;

public class ViewAllOrdersCommand : ICommand
{
    private readonly IGenericRepository<Order> _orderRepository;

    public ViewAllOrdersCommand(IGenericRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Execute()
    {
        var orders = _orderRepository.GetAll().ToArray();
        Console.WriteLine($"Orders ({orders.Length}):");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.Id}, Order status: {order.Status}, Order items ():");
        }
        
    }

    public void Undo()
    {
        
    }

    public string Description => "View all orders";
}