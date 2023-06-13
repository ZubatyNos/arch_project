using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public abstract class OrderState
{
    public OrderContext _context;
    public abstract OrderStatus GetStatusEnum();
    
    public void SetContext(OrderContext context)
    {
        _context = context;
    }

    public virtual void Pay() { }
    public virtual void Cancel() { }
    public virtual void Refund() { }
    public virtual void Deliver() { }
    public virtual void ShowToStore() { }
    public virtual void ToBeDelivered() { }
}