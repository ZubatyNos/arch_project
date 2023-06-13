using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public class NotSeenYetState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.NotSeenYet;

    public override void ToBeDelivered()
    {
        _context.ChangeState(new ToBeDeliveredState());
        _context.DoDeliver();
    }
}