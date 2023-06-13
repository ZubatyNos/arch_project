using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public class RefundedState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.Refunded;
}