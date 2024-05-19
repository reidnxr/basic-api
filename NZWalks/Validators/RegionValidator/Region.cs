using FluentValidation;

namespace NZWalks.Validators.RegionValidator
{
    public class AddValidator : FluentValidation.AbstractValidator<Models.DTO.AddMethod.Region>
    {
        public AddValidator()
        {
            RuleFor(r => r.Code).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Area).GreaterThan(0);
            RuleFor(r => r.Lat).GreaterThan(0);
            RuleFor(r => r.Long).GreaterThan(0);
            RuleFor(r => r.Population).GreaterThanOrEqualTo(0);
        }
    }
    public class UpdateValidator : FluentValidation.AbstractValidator<Models.DTO.UpdateMethod.Region>
    {
        public UpdateValidator()
        {
            RuleFor(r => r.Code).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Area).GreaterThan(0);
            RuleFor(r => r.Lat).GreaterThan(0);
            RuleFor(r => r.Long).GreaterThan(0);
            RuleFor(r => r.Population).GreaterThanOrEqualTo(0);
        }
    }
}
