using MediatR;
using PickPoint.Contracts.Order;

namespace PickPoint.Application.OrderHandlers;

public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand>
{
    public Task<Unit> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}