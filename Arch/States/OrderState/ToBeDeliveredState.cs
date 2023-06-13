using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public class ToBeDeliveredState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.ToBeDelivered;
}