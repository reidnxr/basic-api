using FluentValidation;

namespace Validators.WalkValidator
{
    public class AddValidator : AbstractValidator<Models.DTO.AddMethod.Walk>
    {
        public AddValidator()
        {
            RuleFor(w => w.Name).NotEmpty();
            RuleFor(w => w.Length).GreaterThan(0);
        }
    }
}
