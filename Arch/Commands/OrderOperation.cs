using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.States.OrderState;

namespace ArchProject.Commands;

public class OrderOperation : ICommand
{
    public Order? Order = null;
    
    public void SetOrder(Order order)
    {
        Order = order;
    }
    
    public void Execute()
    {
        if (Order == null)
        {
            Console.WriteLine("Order is not set");
            return;
        }
        
        Console.WriteLine("You can do the following operations:");
        var operations = new List<string>
        {
            "View order details",
            "Cancel order",
            "Pay order",
            "Ask for refund",
        };
        for (var i = 0; i < operations.Count; i++)
        {
            Console.WriteLine($"{i}. {operations[i]}");
        }
        
        Console.WriteLine("Enter operation number:");
        var input = Console.ReadLine();
        var orderContext = new OrderContext(Order);
        
        switch (input)
        {
            case "0":
                Console.WriteLine("Order details:");
                Console.WriteLine($"Order ID: {Order.Id}, Order status: {Order.Status}, Order items ():");
                break;
            case "1":
                orderContext.Cancel();
                break;
            case "2":
                orderContext.Pay();
                break;
            case "3":
                orderContext.Refund();
                break;
        }
        
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }

    public string Description { get; }
}