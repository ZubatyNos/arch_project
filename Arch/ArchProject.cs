using ArchProject.Commands;
using ArchProject.Data;
using ArchProject.Repositories;
using ArchProject.Services;
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
        services.AddSingleton<ICartRepository, CartRepository>();
        services.AddSingleton<IStoreRepository, StoreRepository>();
        services.AddSingleton<IStoreFoodItemRepository, StoreFoodItemRepository>();
        
        // Register services
        services.AddSingleton<ICartService, CartService>();
        services.AddSingleton<IStoreService, StoreService>();
        services.AddSingleton<IStoreFoodItemService, StoreFoodItemService>();
        
        return services;    
    }

    private static void CommandPrint(List<ICommand> commands, List<ICommand> commandHistory)
    {        
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

        // Resolve the required services
        var cartService = serviceProvider.GetRequiredService<ICartService>();
        var storeService = serviceProvider.GetRequiredService<IStoreService>();
        var storeFoodItemService = serviceProvider.GetRequiredService<IStoreFoodItemService>();

        var commands = new List<ICommand>
        {
            new ViewCartCommand(cartService),
            new OrderFoodCommand(storeService, storeFoodItemService)
        };
        
        return commands;
    }
}