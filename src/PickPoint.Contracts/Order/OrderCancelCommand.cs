using MediatR;

namespace PickPoint.Contracts.Order;

public class OrderCancelCommand : IRequest
{
    public OrderCancelCommand(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; }
}