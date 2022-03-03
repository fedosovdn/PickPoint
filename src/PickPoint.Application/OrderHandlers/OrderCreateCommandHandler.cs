using MediatR;
using Microsoft.Extensions.Logging;
using PickPoint.Contracts;
using PickPoint.Contracts.Order;
using PickPoint.Domain;
using PickPoint.Persistence;

namespace PickPoint.Application.OrderHandlers;

public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand>
{
    private readonly IPickPointUnitOfWork _unitOfWork;
    private readonly ILogger<OrderCreateCommandHandler> _logger;

    public OrderCreateCommandHandler(IPickPointUnitOfWork unitOfWork, ILogger<OrderCreateCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Unit> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start creating Order {Order}", request.OrderDto);

        Order order = new()
        {
            Fio = request.OrderDto.Fio,
            Goods = request.OrderDto.Goods.ToList(),
            Number = request.OrderDto.Number,
            Phone = request.OrderDto.Phone,
            Price = request.OrderDto.Price,
            State = request.OrderDto.State,
            Postomat = GetOrCreatePostomat(request.OrderDto.Postomat)
        };
        
        _unitOfWork.OrderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation("Finish creating Order {Order}", request.OrderDto);
        
        return Unit.Value;
    }

    private Postomat? GetOrCreatePostomat(PostomatDto? postomatDto)
    {
        if (postomatDto == null)
        {
            return null;
        }
        
        Postomat? postomat = _unitOfWork.PostomatRepository.Find(postomatDto.Id);

        if (postomat != null)
        {
            return postomat;
        }

        return new Postomat
        {
            Address = postomatDto.Address,
            Number = postomatDto.Number,
            IsActive = postomatDto.IsActive
        };
    }
}