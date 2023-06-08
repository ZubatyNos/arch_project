using ArchProject.Models;

namespace ArchProject.Services;

public interface IOrderService
{
    void AddOrder(Order order);
    List<Order> GetAllOrders();
    void AddOrderStoreFoodItems(List<OrderStoreFoodItem> orderStoreFoodItems);
}