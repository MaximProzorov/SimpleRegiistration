using FluentValidation;
using SimpleRegistration.Api.Models;

namespace SimpleRegistration.Api.Validators;

public class RegisterModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterModelValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login is required")
            .EmailAddress().WithMessage("Valid email is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Matches("[A-Za-z]").WithMessage("Letter is required")
            .Matches(@"\d").WithMessage("Digit is required");

        RuleFor(x => x.RepeatedPassword)
            .Must((y, z) => y.Password == z).WithMessage("Passwords must be same");

        RuleFor(x => x.IsConfirmed)
            .Must(y => y).WithMessage("You should agree rules");
    }
}
