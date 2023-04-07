using FluentValidation;
using GetTogether.Common.DTO.User;

namespace GetTogether.WEBAPI.Validation.User;

public class NewUserValidator: AbstractValidator<NewUserDTO>
{
    public NewUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .Length(3, 30).WithMessage("Name length must be from 3 to 30");
        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email adress");
    }
}
