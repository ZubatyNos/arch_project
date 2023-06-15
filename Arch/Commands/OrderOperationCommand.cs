using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.Repositories;
using ArchProject.States.OrderState;

namespace ArchProject.Commands;

public class OrderOperationCommand : ICommand
{
    
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<OrderStoreFood> _orderStoreFoodRepository;
    private readonly IGenericRepository<StoreFood> _storeFoodRepository;
    public OrderOperationCommand(
        IGenericRepository<Order> orderRepository, 
        IGenericRepository<OrderStoreFood> orderStoreFoodRepository, IGenericRepository<StoreFood> storeFoodRepository)
    {
        _orderRepository = orderRepository;
        _orderStoreFoodRepository = orderStoreFoodRepository;
        _storeFoodRepository = storeFoodRepository;
    }

    public void Execute()
    {
        Console.WriteLine("Choose order id to perform actions on:");
        
        var input = Console.ReadLine();
        var inputId = int.Parse(input ?? string.Empty);
        var order = _orderRepository.GetById(inputId);
        if (order == null)
        {
            Console.WriteLine("Order not found");
            return;
        }

        Console.WriteLine("Choose from the following operations:");
        Console.WriteLine("0. View order details");
        Console.WriteLine("1. Cancel order");
        Console.WriteLine("2. Pay order");
        Console.WriteLine("3. Ask for refund");
        

        
        Console.WriteLine("Enter operation number:");
        input = Console.ReadLine();
        var orderContext = new OrderContext(order, _orderRepository);
        
        switch (input)
        {
            case "0":
                PrintDetails(order);
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

    public void PrintDetails(Order order)
    {
        Console.WriteLine($"Order details:");
        Console.WriteLine($"Order status: {order.Status}");
        var orderStoreFoods = _orderStoreFoodRepository.Find(
            osf => osf.OrderId == order.Id,
            osf => osf.Food
        );

        var storeFoods = _storeFoodRepository.GetAll().ToList();
        foreach (var storeFood in storeFoods)
        {
            var orderStoreFood = orderStoreFoods.FirstOrDefault(
                osf => osf.FoodId == storeFood.FoodId && osf.StoreId == storeFood.StoreId
                );
            if (orderStoreFood != null)
            {
                Console.WriteLine(
                    $"Food name: {storeFood.Food.Name}," +
                    $"Food price: {storeFood.Price} * {orderStoreFood.Quantity} = " +
                    $"{storeFood.Price * orderStoreFood.Quantity}"
                    );
            }
        }
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }

    public string Description { get; }
}