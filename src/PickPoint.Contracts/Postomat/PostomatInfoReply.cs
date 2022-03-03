namespace PickPoint.Contracts.Postomat;

public class PostomatInfoReply
{
    public PostomatInfoReply(PostomatDto postomatDto)
    {
        PostomatDto = postomatDto;
    }

    public PostomatDto PostomatDto { get; }
}