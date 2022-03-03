namespace PickPoint.Contracts;

public class PostomatDto
{
    public int Id { get; set; }
    
    public string Number { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }
}