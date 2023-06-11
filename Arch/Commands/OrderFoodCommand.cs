using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Commands;

public class OrderFoodCommand : ICommand
{
    private readonly IGenericRepository<CartEntry> _cartEntryRepository;
    private readonly IGenericRepository<Store> _storeRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<StoreFoodItem> _storeFoodItemRepository;
    private readonly IGenericRepository<OrderStoreFoodItem> _orderStoreFoodItemRepository;

    public OrderFoodCommand(
        IGenericRepository<CartEntry> cartEntryRepository,
        IGenericRepository<Store> storeRepository,
        IGenericRepository<Order> orderRepository,
        IGenericRepository<StoreFoodItem> storeFoodItemRepository,
        IGenericRepository<OrderStoreFoodItem> orderStoreFoodItemRepository
    )
    {
        _cartEntryRepository = cartEntryRepository;
        _storeRepository = storeRepository;
        _orderRepository = orderRepository;
        _storeFoodItemRepository = storeFoodItemRepository;
        _orderStoreFoodItemRepository = orderStoreFoodItemRepository;
    }

    public void Execute()
    {
        var store = SelectStore();
        if (store == null)
        {
            return;
        }

        var selectFoodItemsOfStore = SelectStoreFoodItems(store.Id);
        _storeFoodItemRepository.AddRange(selectFoodItemsOfStore);
        
        
        Console.WriteLine("Do you want to pay now? (y/n)");
        var input = Console.ReadLine();
        switch (input)
        {
            case "n" or "N":
                return;
            case "y" or "Y":
                OrderFood();
                break;
        }
    }

    private void OrderFood()
    {
        var order = new Order
        {
            Status = OrderStatus.Paid
        };
        _orderRepository.Add(order);
        var orderStoreFoodItems = _cartEntryRepository.GetAll().Select(cartEntry => new OrderStoreFoodItem
        {
            OrderId = order.Id,
            StoreId = cartEntry.StoreId,
            FoodItemId = cartEntry.FoodItemId,
            Quantity = cartEntry.Quantity
        }).ToList();
        _orderStoreFoodItemRepository.AddRange(orderStoreFoodItems);
    }

    private Store? SelectStore()
    {
        Console.WriteLine("Available Stores:");
        var stores = _storeRepository.GetAll().ToArray();
        foreach (var store in stores)
        {
            Console.WriteLine($"Store id: {store.Id}, Name: {store.Name}, Opening hours: {store.OpeningTime.ToString(@"hh\:mm")} - {store.ClosingTime.ToString(@"hh\:mm")}");
        }
        
        Console.Write("Please enter the id of the store you want to order from:");
        var input = Console.ReadLine();
        var inputId = int.Parse(input ?? string.Empty);
        if (stores.Any(s => s.Id == inputId))
        {
            var store = stores.First(s => s.Id == inputId);
            if (store.IsOpen() == false)
            {
                Console.WriteLine("Store is closed!");
            }
            return store;
        }
        Console.WriteLine("Invalid store id!");
        return null;
    }

    private List<StoreFoodItem> SelectStoreFoodItems(int storeId)
    {
        var selectedStoreFoodItems = new List<StoreFoodItem>();
        StoreFoodItem[] storeFoodItems = _storeFoodItemRepository
            .Find(sfi => sfi.StoreId == storeId,
                sfi => sfi.FoodItem
                )
            .ToArray();
        if (storeFoodItems.Length == 0)
        {
            Console.WriteLine("No food items available in this store!");
            return selectedStoreFoodItems;
        }
        while (true)
        {
            for (int i = 0; i < storeFoodItems.Length; i++)
            {
                var storeFoodItem = storeFoodItems[i];
                Console.WriteLine($"{i}: {storeFoodItem.FoodItem.Name}, Price: {storeFoodItem.Price}");
            }

            Console.Write("Please enter the id of the food you want to order or type 'q' to end selection:");
            var input = Console.ReadLine();
            if (input is "q" or "Q")
            {
                return selectedStoreFoodItems;
            }
            
            var id = int.Parse(input ?? string.Empty);
            if (id < storeFoodItems.Length && id >= 0)
            {
                var storeFoodItem = storeFoodItems[id];
                selectedStoreFoodItems.Add(storeFoodItem);
                Console.WriteLine("Food added to cart!");
                continue;
            }
            Console.WriteLine("Invalid food id!"); 
        }
    }
    
    public void Undo()
    {
        // idk how to undo a complex command like this
        // if there was payment made then undo payment
        // if there were foods selected then unselect them
    }

    public string Description => "Order food";
}