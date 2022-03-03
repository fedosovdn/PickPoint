using MediatR;

namespace PickPoint.Contracts.Order;

public class OrderUpdateCommand : IRequest
{
    public OrderUpdateCommand(OrderDto orderDto)
    {
        OrderDto = orderDto;
    }

    public OrderDto OrderDto { get; }
}