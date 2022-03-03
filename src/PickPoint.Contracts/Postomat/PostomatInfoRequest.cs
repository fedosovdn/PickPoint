using MediatR;

namespace PickPoint.Contracts.Postomat;

public class PostomatInfoRequest : IRequest<PostomatInfoReply>
{
    public PostomatInfoRequest(int id)
    {
        Id = id;
    }

    public int Id { get; }
}