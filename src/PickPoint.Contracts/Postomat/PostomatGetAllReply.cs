namespace PickPoint.Contracts.Postomat;

public class PostomatGetAllReply
{
    public PostomatGetAllReply(PostomatDto[] postomatDtos)
    {
        PostomatDtos = postomatDtos;
    }

    public PostomatDto[] PostomatDtos { get; }
}