using MediatR;
using Microsoft.Extensions.Logging;
using PickPoint.Contracts;
using PickPoint.Contracts.Exceptions;
using PickPoint.Contracts.Postomat;
using PickPoint.Domain;
using PickPoint.Persistence;

namespace PickPoint.Application.PostomatHandlers;

public class PostomatInfoRequestHandler : IRequestHandler<PostomatInfoRequest, PostomatInfoReply>
{
    private readonly IPickPointUnitOfWork _unitOfWork;
    private readonly ILogger<PostomatInfoRequestHandler> _logger;

    public PostomatInfoRequestHandler(IPickPointUnitOfWork unitOfWork, ILogger<PostomatInfoRequestHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task<PostomatInfoReply> Handle(PostomatInfoRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start getting Postomat info {PostomatId}", request.Id);

        Postomat? postomat = _unitOfWork.PostomatRepository.Find(request.Id);

        if (postomat == null)
        {
            _logger.LogError("No postomat with the {Id}", request.Id);
            throw new ItemNotFoundException();
        }

        var postomatDto = new PostomatDto
        {
            Address = postomat.Address,
            Id = postomat.Id,
            Number = postomat.Number,
            IsActive = postomat.IsActive
        };
        
        _logger.LogInformation("Finish getting Postomat info {PostomatId}", request.Id);
        
        return Task.FromResult(new PostomatInfoReply(postomatDto));
    }
}