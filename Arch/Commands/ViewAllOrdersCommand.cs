using ArchProject.Services;

namespace ArchProject.Commands;

public class ViewAllOrdersCommand : ICommand
{
    private readonly IOrderService _orderService;

    public ViewAllOrdersCommand(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public void Execute()
    {
        var orders = _orderService.GetAllOrders();
        Console.WriteLine($"Orders ({orders.Count}):");
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