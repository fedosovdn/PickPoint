using MediatR;

namespace PickPoint.Contracts.Order;

public class OrderCreateCommand : IRequest
{
    public OrderCreateCommand(OrderDto orderDto)
    {
        OrderDto = orderDto;
    }

    public OrderDto OrderDto { get; }
}