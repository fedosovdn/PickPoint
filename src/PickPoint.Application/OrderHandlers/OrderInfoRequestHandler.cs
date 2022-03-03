using MediatR;
using Microsoft.Extensions.Logging;
using PickPoint.Contracts;
using PickPoint.Contracts.Exceptions;
using PickPoint.Contracts.Order;
using PickPoint.Domain;
using PickPoint.Persistence;

namespace PickPoint.Application.OrderHandlers;

public class OrderInfoRequestHandler : IRequestHandler<OrderInfoRequest, OrderInfoReply>
{
    private readonly IPickPointUnitOfWork _unitOfWork;
    private readonly ILogger<OrderInfoRequestHandler> _logger;

    public OrderInfoRequestHandler(IPickPointUnitOfWork unitOfWork, ILogger<OrderInfoRequestHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task<OrderInfoReply> Handle(OrderInfoRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start getting Order info {OrderId}", request.OrderId);

        Order? order = _unitOfWork.OrderRepository.GetAllIncluded().SingleOrDefault(o => o.Id == request.OrderId);

        if (order == null)
        {
            _logger.LogError("No order with the {Id}", request.OrderId);
            throw new ItemNotFoundException();
        }

        var orderDto = new OrderDto
        {
            Fio = order.Fio,
            Goods = order.Goods.ToArray(),
            Id = order.Id,
            Number = order.Number,
            Phone = order.Phone,
            Price = order.Price,
            State = order.State,
            Postomat = order.Postomat != null
                ? new PostomatDto
                {
                    Address = order.Postomat.Address,
                    Id = order.Postomat.Id,
                    Number = order.Postomat.Number,
                    IsActive = order.Postomat.IsActive
                }
                : null
        };
        
        _logger.LogInformation("Finish getting Order info {OrderId}", request.OrderId);

        return Task.FromResult(new OrderInfoReply(orderDto));
    }
}