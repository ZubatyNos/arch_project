using ArchProject.Commands;
using ArchProject.Data;
using ArchProject.Models;
using ArchProject.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArchProject;

class Arch
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the Food Ordering CLI Application!");
        
        var commands = SetupCommands();


        var commandHistory = new List<ICommand>();
        while (true)
        {
            CommandPrint(commands, commandHistory);

            string? input = Console.ReadLine();
            
            if (input is "q" or "Q")
            {
                break;
            }
            if (input is "u" or "U")
            {
                var command = commandHistory.Last();
                commandHistory.RemoveAt(commands.Count - 1);
                command.Undo();
                continue;
            }

            int commandInput = int.Parse(input ?? string.Empty);

            if (commandInput < commands.Count && commandInput >= 0)
            {
                var command = commands[commandInput];
                commandHistory.Add(command);
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command!");
            }
        }
    }

    private static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddDbContext<MyDbContext>();
        
        // Register repositories
        services.AddSingleton<IGenericRepository<Store>, GenericRepository<Store>>();
        services.AddSingleton<IGenericRepository<Order>, GenericRepository<Order>>();
        services.AddSingleton<IGenericRepository<OrderStoreFoodItem>, GenericRepository<OrderStoreFoodItem>>();
        services.AddSingleton<IGenericRepository<FoodItem>, GenericRepository<FoodItem>>();
        services.AddSingleton<IGenericRepository<CartEntry>, GenericRepository<CartEntry>>();
        services.AddSingleton<IGenericRepository<StoreFoodItem>, GenericRepository<StoreFoodItem>>();
        
        return services;    
    }

    private static void CommandPrint(List<ICommand> commands, List<ICommand> commandHistory)
    {
        Console.WriteLine();
        Console.WriteLine("--------------------");
        Console.WriteLine("COMMANDS:");
        if (commandHistory.Count > 0)
        {
            Console.WriteLine("Undo last command: u");
        }
        foreach (var command in commands)
        {
            Console.WriteLine($"{commands.IndexOf(command)}: {command.Description}");
        }            
        Console.Write("Please enter the character corresponding to the command you want to execute (or 'q' to quit):");
    }
    
    private static List<ICommand> SetupCommands()
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the required repositories
        var cartEntryRepository = serviceProvider.GetRequiredService<IGenericRepository<CartEntry>>();
        var storeRepository = serviceProvider.GetRequiredService<IGenericRepository<Store>>();
        var storeFoodItemRepository = serviceProvider.GetRequiredService<IGenericRepository<StoreFoodItem>>();
        var orderRepository = serviceProvider.GetRequiredService<IGenericRepository<Order>>();
        var orderStoreFoodItemRepository = serviceProvider.GetRequiredService<IGenericRepository<OrderStoreFoodItem>>();
        var foodItemRepository = serviceProvider.GetRequiredService<IGenericRepository<FoodItem>>();
        
        
        var commands = new List<ICommand>
        {
            new ViewCartCommand(cartEntryRepository),
            new OrderFoodCommand(cartEntryRepository, storeRepository, orderRepository, storeFoodItemRepository, orderStoreFoodItemRepository),
            new ViewAllOrdersCommand(orderRepository)
        };
        
        return commands;
    }
}