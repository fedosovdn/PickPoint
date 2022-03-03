namespace PickPoint.Contracts.Order;

public class OrderInfoReply
{
    public OrderInfoReply(OrderDto orderDto)
    {
        OrderDto = orderDto;
    }

    public OrderDto OrderDto { get; }
}