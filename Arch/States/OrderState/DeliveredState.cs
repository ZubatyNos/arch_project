using ArchProject.Enums;

namespace ArchProject.States.OrderState;

public class DeliveredState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.Delivered;
}