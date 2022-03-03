using PickPoint.Domain;

namespace PickPoint.Contracts;

public class OrderDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public OrderState State { get; set; }

    public string[]? Goods { get; set; }

    public decimal Price { get; set; }

    public PostomatDto? Postomat { get; set; }

    public string? Phone { get; set; }

    public string Fio { get; set; }
}