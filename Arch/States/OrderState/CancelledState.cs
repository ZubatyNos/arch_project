using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public class CancelledState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.Cancelled;
}