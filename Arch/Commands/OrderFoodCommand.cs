using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.Repositories;
using ArchProject.States.OrderState;

namespace ArchProject.Commands;

public class OrderFoodCommand : ICommand
{
    private readonly IGenericRepository<CartEntry> _cartEntryRepository;
    private readonly IGenericRepository<Store> _storeRepository;
    private readonly IGenericRepository<Order> _orderRepository;
    private readonly IGenericRepository<StoreFood> _storeFoodRepository;
    private readonly IGenericRepository<OrderStoreFood> _orderStoreFoodRepository;

    public OrderFoodCommand(
        IGenericRepository<CartEntry> cartEntryRepository,
        IGenericRepository<Store> storeRepository,
        IGenericRepository<Order> orderRepository,
        IGenericRepository<StoreFood> storeFoodRepository,
        IGenericRepository<OrderStoreFood> orderStoreFoodRepository
    )
    {
        _cartEntryRepository = cartEntryRepository;
        _storeRepository = storeRepository;
        _orderRepository = orderRepository;
        _storeFoodRepository = storeFoodRepository;
        _orderStoreFoodRepository = orderStoreFoodRepository;
    }

    public void Execute()
    {
        var store = SelectStore();
        if (store == null)
        {
            return;
        }
        
        var selectedStoreFoods = SelectStoreFoods(store.Id);
        AddToCart(store, selectedStoreFoods);
        
        
        Console.WriteLine("Do you want to make an order now? (y/n)");
        var input = Console.ReadLine();
        switch (input)
        {
            case "n" or "N":
                return;
            case "y" or "Y":
                OrderFood();
                EmptyCart();
                break;
        }
    }

    private void EmptyCart()
    {
        _cartEntryRepository.RemoveRange(_cartEntryRepository.GetAll());
    }
    
    private void AddToCart(Store store, List<StoreFood> selectedStoreFoods)
    {
        var cartEntries = _cartEntryRepository.Find(ce => ce.StoreId == store.Id).ToList();
        var storeFoodsByQuantity = selectedStoreFoods.GroupBy(sf => sf.FoodId).Select(g => new
        {
            FoodId = g.Key,
            Quantity = g.Count()
        });
        
        foreach (var item in storeFoodsByQuantity)
        {
            Console.WriteLine($"Adding {item.Quantity} {item.FoodId} to cart");
            var cartEntry = cartEntries.FirstOrDefault(ce => ce.FoodId == item.FoodId);
            if (cartEntry == null)
            {
                Console.WriteLine("Creating new cart entry");
                Console.WriteLine($"StoreId: {store.Id}, FoodId: {item.FoodId}, Quantity: {item.Quantity}");
                cartEntry = new CartEntry
                {
                    StoreId = store.Id,
                    FoodId = item.FoodId,
                    Quantity = item.Quantity
                };
                _cartEntryRepository.Add(cartEntry);
            }
            else
            {
                cartEntry.Quantity += item.Quantity;
                _cartEntryRepository.Update(cartEntry);
            }
        }
    }
    
    private void OrderFood()
    {
        var order = new Order
        {
            Status = OrderStatus.Paid
        };
        var orderContext = new OrderContext(order, _orderRepository);
        
        var orderStoreFoods = _cartEntryRepository.GetAll().Select(cartEntry => new OrderStoreFood
        {
            OrderId = orderContext.Order.Id,
            StoreId = cartEntry.StoreId,
            FoodId = cartEntry.FoodId,
            Quantity = cartEntry.Quantity
        }).ToList();
        
        _orderStoreFoodRepository.AddRange(orderStoreFoods);
        orderContext.ShowToStore();
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

    private List<StoreFood> SelectStoreFoods(int storeId)
    {
        var selectedStoreFoods = new List<StoreFood>();
        StoreFood[] storeFoods = _storeFoodRepository
            .Find(sfi => sfi.StoreId == storeId,
                sfi => sfi.Food
                )
            .ToArray();
        if (storeFoods.Length == 0)
        {
            Console.WriteLine("No food items available in this store!");
            return selectedStoreFoods;
        }
        while (true)
        {
            for (int i = 0; i < storeFoods.Length; i++)
            {
                var storeFood = storeFoods[i];
                Console.WriteLine($"{i}: {storeFood.Food.Name}, Price: {storeFood.Price}");
            }
    
            Console.Write("Please enter the id of the food you want to order or type 'q' to end selection:");
            var input = Console.ReadLine();
            if (input is "q" or "Q")
            {
                return selectedStoreFoods;
            }
            
            var id = int.Parse(input ?? string.Empty);
            if (id < storeFoods.Length && id >= 0)
            {
                var storeFood = storeFoods[id];
                selectedStoreFoods.Add(storeFood);
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