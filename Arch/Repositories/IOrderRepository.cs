using ArchProject.Models;

namespace ArchProject.Repositories;

public interface IOrderRepository
{
    void AddOrder(Order order);
    List<Order> GetAllOrders();
    void AddOrderStoreFoodItems(List<OrderStoreFoodItem> orderStoreFoodItems);
}