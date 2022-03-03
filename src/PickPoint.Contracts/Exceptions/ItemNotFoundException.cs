namespace PickPoint.Contracts.Exceptions;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() : base("Item not found.")
    {
    }
    
    public ItemNotFoundException(string msg) : base(msg)
    {
    }
}