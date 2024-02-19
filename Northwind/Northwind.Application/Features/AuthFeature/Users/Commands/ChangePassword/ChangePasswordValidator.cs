using FluentValidation;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage("New password is empty")
                 .NotNull().WithMessage("New password is required");

            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.NewPassword)
                 .WithMessage("Not matching with new password field!");
        }
    }
}
