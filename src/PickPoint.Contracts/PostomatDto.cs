using System.Text.RegularExpressions;
using FluentValidation;

namespace PickPoint.Contracts;

public class PostomatDto
{
    public int Id { get; set; }
    
    public string Number { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }
}

public class PostomatValidator : AbstractValidator<PostomatDto>
{
    public PostomatValidator()
    {
        string pattern = @"^\d{4}-\d{3}$";
        Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        RuleFor(dto => dto.Number).Must(s => rx.IsMatch(s));
    }
}