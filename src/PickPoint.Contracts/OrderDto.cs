using System.Text.RegularExpressions;
using FluentValidation;
using PickPoint.Domain;

namespace PickPoint.Contracts;

public class OrderDto
{
    public int Id { get; set; }

    public int Number { get; set; }

    public OrderState State { get; set; }

    public string[] Goods { get; set; }

    public decimal Price { get; set; }

    public PostomatDto? Postomat { get; set; }

    public string? Phone { get; set; }

    public string Fio { get; set; }
}

public class OrderDtoValidator : AbstractValidator<OrderDto>
{
    public OrderDtoValidator()
    {
        string pattern = @"^[\+]7\d{3}-\d{3}-\d{2}-\d{2}$";
        Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        RuleFor(dto => dto.Goods).Must(goods => goods != null && goods.Length > 0 && goods.Length < 11)
            .WithMessage("В заказ может попадать не более 10 и не менее 1 товаров");
        RuleFor(dto => dto.Phone).Must(s => !string.IsNullOrWhiteSpace(s) && rx.IsMatch(s) || string.IsNullOrWhiteSpace(s));
    }
}