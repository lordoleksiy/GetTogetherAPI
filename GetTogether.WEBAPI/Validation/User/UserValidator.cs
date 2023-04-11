using FluentValidation;
using GetTogether.Common.DTO.User;

namespace GetTogether.WEBAPI.Validation.User;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .Length(3, 30).WithMessage("Name length must be from 3 to 30");
        RuleFor(u => u.Login)
            .NotEmpty()
            .Length(3, 30).WithMessage("Name length must be from 3 to 30");
    }
}
