using FluentValidation;

namespace NZWalks.Validators.WalkValidator
{
    public class AddValidator : FluentValidation.AbstractValidator<Models.DTO.AddMethod.Walk>
    {
        public AddValidator()
        {
            RuleFor(w => w.Name).NotEmpty();
            RuleFor(w => w.Length).GreaterThan(0);
        }
    }
}
