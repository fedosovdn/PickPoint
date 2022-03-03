namespace PickPoint.Domain;

public class Order
{
    public int Id { get; set; }

    public int Number { get; set; }

    public OrderState State { get; set; }

    public List<string> Goods { get; set; } = new();

    public decimal Price { get; set; }

    public Postomat? Postomat { get; set; }

    public string? Phone { get; set; }

    public string Fio { get; set; }
}