using MediatR;
using PickPoint.Contracts.Order;

namespace PickPoint.Application.OrderHandlers;

public class OrderCancelCommandHandler : IRequestHandler<OrderCancelCommand>
{
    public Task<Unit> Handle(OrderCancelCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}