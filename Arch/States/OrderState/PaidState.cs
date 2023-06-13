﻿using ArchProject.States.OrderState;

namespace ArchProject.Enums;

public class PaidState : OrderState
{
    public override OrderStatus GetStatusEnum() => OrderStatus.Paid;
    
    public override void Refund()
    {
        _context.DoRefund();
    }
    
    public override void ShowToStore()
    {
        _context.ChangeState(new NotSeenYetState());
        _context.DoShowToStore();
    }
    
}