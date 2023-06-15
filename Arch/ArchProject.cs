using ArchProject.Commands;
using ArchProject.Data;
using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ArchProject;

class Arch
{
    private static void Main()
    {
        Console.WriteLine("Welcome to the Food Ordering CLI Application!");
        var services = ConfigureServices();
        var commands = SetupCommands(services);

        var storeWorkerThread = new Thread(() => SimulateStore(services));
        storeWorkerThread.Start();
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
                Console.WriteLine();
                command.Execute();
                Console.WriteLine();
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
        services.AddSingleton<IGenericRepository<Food>, GenericRepository<Food>>();
        services.AddSingleton<IGenericRepository<CartEntry>, GenericRepository<CartEntry>>();
        services.AddSingleton<IGenericRepository<StoreFood>, GenericRepository<StoreFood>>();
        services.AddSingleton<IGenericRepository<OrderStoreFood>, GenericRepository<OrderStoreFood>>();

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

    private static List<ICommand> SetupCommands(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the required repositories
        var cartEntryRepository = serviceProvider.GetRequiredService<IGenericRepository<CartEntry>>();
        var storeRepository = serviceProvider.GetRequiredService<IGenericRepository<Store>>();
        var orderRepository = serviceProvider.GetRequiredService<IGenericRepository<Order>>();
        var foodRepository = serviceProvider.GetRequiredService<IGenericRepository<Food>>();
        var storeFoodRepository = serviceProvider.GetRequiredService<IGenericRepository<StoreFood>>();
        var orderStoreFoodRepository = serviceProvider.GetRequiredService<IGenericRepository<OrderStoreFood>>();
          
        
        // Setup commands
        var orderOperationMacroCommand = new MacroCommand(new List<ICommand>
        {
            new ViewAllOrdersCommand(orderRepository),
            new OrderOperationCommand(orderRepository, orderStoreFoodRepository, storeFoodRepository)
        });
        orderOperationMacroCommand.Description = "Check orders";
        
        var commands = new List<ICommand>
        {
            new ViewCartCommand(cartEntryRepository),
            orderOperationMacroCommand,
            new OrderFoodCommand(cartEntryRepository, storeRepository, orderRepository, storeFoodRepository, orderStoreFoodRepository),
        };
        
        return commands;
    }

    private static void SimulateStore(ServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the required repositories
        var orderRepository = serviceProvider.GetRequiredService<IGenericRepository<Order>>();
        var rand = new Random();

        while (true)
        {
            var orders = orderRepository.GetAll().Where(
                o => o.Status is OrderStatus.Paid or OrderStatus.NotSeenYet or OrderStatus.ToBeDelivered
                    )
                .ToList();
            var order = orders.FirstOrDefault();
            if (order is not null)
            {
                order.Status = order.Status switch {
                    OrderStatus.Paid => OrderStatus.NotSeenYet,
                    OrderStatus.NotSeenYet => OrderStatus.ToBeDelivered,
                    OrderStatus.ToBeDelivered => OrderStatus.Delivered,
                    _ => throw new ArgumentOutOfRangeException("xddd")
                }; 
                orderRepository.Update(order);
            }
            Thread.Sleep(5000);
        }
    }
}