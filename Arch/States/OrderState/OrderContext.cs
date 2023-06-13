using System.Timers;
using Timer = System.Timers.Timer;
using ArchProject.Enums;
using ArchProject.Models;

namespace ArchProject.States.OrderState;

public class OrderContext
{
    private OrderState _state;
    public Order Order;

    public OrderContext(Order order)
    {
        Order = order;
        ChangeState(GetStateFromEnum(order.Status));
    }

    public void ChangeState(OrderState state)
    {
        _state = state;
        _state.SetContext(this);
        Order.Status = _state.GetStatusEnum();
    }

    public OrderState GetStateFromEnum(OrderStatus status)
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
    
    public void Pay() => _state.Pay();
    public void Cancel() => _state.Cancel();
    public void Refund() => _state.Refund();
    public void Deliver() => _state.Deliver();
    public void ToBeDelivered() => _state.ToBeDelivered();
    public void ShowToStore() => _state.ShowToStore();

    
    // WHAT TO DO WITH THESE?
    public void DoRefund()
    {
        
    }
    public void DoCancel()
    {
        
    }
    public void DoDeliver()
    {
       
    }
    public void DoShowToStore()
    {
        
    }
    
    
}