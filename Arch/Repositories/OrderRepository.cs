using ArchProject.Data;
using ArchProject.Models;

namespace ArchProject.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _dbContext;

    public OrderRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddOrder(Order order)
    {
        _dbContext.Order.Add(order);
    }

    public List<Order> GetAllOrders()
    {
        return _dbContext.Order.ToList();
    }

    public void AddOrderStoreFoodItems(List<OrderStoreFoodItem> orderStoreFoodItems)
    {
        _dbContext.OrderStoreFoodItem.AddRange(orderStoreFoodItems);
    }
}