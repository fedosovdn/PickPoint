using MediatR;
using Microsoft.Extensions.Logging;
using PickPoint.Contracts;
using PickPoint.Contracts.Postomat;
using PickPoint.Persistence;

namespace PickPoint.Application.PostomatHandlers;

public class PostomatGetAllRequestHandler : IRequestHandler<PostomatGetAllRequest, PostomatGetAllReply>
{
    private readonly IPickPointUnitOfWork _unitOfWork;
    private readonly ILogger<PostomatGetAllRequestHandler> _logger;

    public PostomatGetAllRequestHandler(IPickPointUnitOfWork unitOfWork, ILogger<PostomatGetAllRequestHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task<PostomatGetAllReply> Handle(PostomatGetAllRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start getting all Postomats info");

        var postomats = _unitOfWork.PostomatRepository.GetAll()
            .Where(postomat => postomat.IsActive)
            .OrderBy(postomat => postomat.Number)
            .Select(postomat => new PostomatDto
            {
                Address = postomat.Address,
                Id = postomat.Id,
                Number = postomat.Number,
                IsActive = postomat.IsActive
            })
            .ToArray();
        
        _logger.LogInformation("Finish getting all Postomats info");
        
        return Task.FromResult(new PostomatGetAllReply(postomats));
    }
}