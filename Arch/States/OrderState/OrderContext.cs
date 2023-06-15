using System.Timers;
using Timer = System.Timers.Timer;
using ArchProject.Enums;
using ArchProject.Models;
using ArchProject.Repositories;

namespace ArchProject.States.OrderState;

public class OrderContext
{
    private OrderState _state;
    private readonly IGenericRepository<Order> _orderRepository;
    public Order Order;

    public OrderContext(Order order, IGenericRepository<Order> orderRepository)
    {
        Order = order;
        _orderRepository = orderRepository;
        ChangeState(GetStateFromEnum(order.Status));
    }

    public void ChangeState(OrderState state)
    {
        _state = state;
        _state.SetContext(this);
        Order.Status = _state.GetStatusEnum();
        Console.WriteLine($"Order status changed to {_state.GetStatusEnum()}");
        var dbOrder = _orderRepository.Find(o => o.Id == Order.Id).FirstOrDefault();
        if (dbOrder == null)
        {
            _orderRepository.Add(Order);
        }
        else
        {
            _orderRepository.Update(Order);
        }
    }
    
    public void Pay() => _state.Pay();
    public void Cancel() => _state.Cancel();
    public void Refund() => _state.Refund();
    public void Deliver() => _state.Deliver();
    public void ToBeDelivered() => _state.ToBeDelivered();
    public void ShowToStore() => _state.ShowToStore();

    private OrderState GetStateFromEnum(OrderStatus status)
    {
        return status switch
        {
            OrderStatus.Cancelled => new CancelledState(),
            OrderStatus.Delivered => new DeliveredState(),
            OrderStatus.Paid => new PaidState(),
            OrderStatus.Refunded => new RefundedState(),
            OrderStatus.NotSeenYet => new NotSeenYetState(),
            OrderStatus.ToBeDelivered => new ToBeDeliveredState(),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)  
        };
    }
    
    
}