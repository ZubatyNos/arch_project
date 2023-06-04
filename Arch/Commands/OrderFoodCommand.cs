using ArchProject.Models;
using ArchProject.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;

namespace ArchProject.Commands;

public class OrderFoodCommand : ICommand
{
    private readonly IStoreService _storeService;
    private readonly IStoreFoodItemService _storeFoodItemService;

    public OrderFoodCommand(IStoreService storeService, IStoreFoodItemService storeFoodItemService)
    {
        _storeService = storeService;
        _storeFoodItemService = storeFoodItemService;
    }

    public void Execute()
    {
        var store = SelectStore();
        if (store == null)
        {
            // TODO: ????
            return;
        }
        // maybe have a loop here to select multiple foods?
        var storeFoodItems = new List<StoreFoodItem>();
        var storeFoodItem = SelectFoodItemsOfStore(store.Id);
        
        // TODO: ask for payment
        
       
    }

    public Store? SelectStore()
    {
        Console.WriteLine("Available Stores:");
        var stores = _storeService.GetAllStores();
        foreach (var store in stores)
        {
            Console.WriteLine($"Store id: {store.Id}, Name: {store.Name}, Opening hours: {store.OpeningTime.ToString(@"hh\:mm")} - {store.ClosingTime.ToString(@"hh\:mm")}");
        }
        
        Console.Write("Please enter the id of the store you want to order from:");
        string? input = Console.ReadLine();
        int id = int.Parse(input ?? string.Empty);
        if (stores.Any(s => s.Id == id))
        {
            var store = stores.First(s => s.Id == id);
            Console.WriteLine(store.IsOpen() ? "Store is open!" : "Store is closed!");
            return store;
        }
        Console.WriteLine("Invalid store id!");
        return null;
    }

    public StoreFoodItem? SelectFoodItemsOfStore(int storeId)
    {
        var storeFoodItems = _storeFoodItemService.GetAllStoreFoodItemsByStoreId(storeId);
        foreach (var storeFoodItem in storeFoodItems)
        {
            Console.WriteLine($"Food id: {storeFoodItems.IndexOf(storeFoodItem)}, Name: {storeFoodItem.FoodItem.Name}, Price: {storeFoodItem.Price}");
        }
        
        Console.Write("Please enter the id of the food you want to order:");
        var input = Console.ReadLine();
        var id = int.Parse(input ?? string.Empty);
        if (id < storeFoodItems.Count && id >= 0)
        {
            var storeFoodItem = storeFoodItems[id];
            Console.WriteLine($"You ordered {storeFoodItem.FoodItem.Name} for {storeFoodItem.Price}");
            return storeFoodItem;
        }
        Console.WriteLine("Invalid food id!");
        return null;

    }
    public void Undo()
    {
        // idk how to undo a complex command like this
        // if there was payment made then undo payment
        // if there were foods selected then unselect them
    }

    public string Description { get; } = "Order food";
}