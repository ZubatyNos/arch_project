using ArchProject.States.OrderState;

namespace ArchProject.Enums;

public class PaidState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.Paid;

    public override void Refund()
    {
        _context.ChangeState(new RefundedState());
    }

    public override void ShowToStore()
    {
        _context.ChangeState(new NotSeenYetState());
    }
    
}