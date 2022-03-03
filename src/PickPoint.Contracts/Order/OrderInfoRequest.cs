using MediatR;

namespace PickPoint.Contracts.Order;

public class OrderInfoRequest : IRequest<OrderInfoReply>
{
    public OrderInfoRequest(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; }
}