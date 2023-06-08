using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void AddOrder(Order order)
    {
        _orderRepository.AddOrder(order);
    }

    public List<Order> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }

    public void AddOrderStoreFoodItems(List<OrderStoreFoodItem> orderStoreFoodItems)
    {
        _orderRepository.AddOrderStoreFoodItems(orderStoreFoodItems);
    }
}