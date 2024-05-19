using FluentValidation;

namespace Validators.UserValidator
{
    public class LoginValidator : AbstractValidator<Models.DTO.Login>
    {
        public LoginValidator()
        {
            RuleFor(u => u.email).NotEmpty();
            RuleFor(u => u.password).NotEmpty();
        }
    }
}
