using FluentValidation;

namespace NZWalks.Validators.WalkDifficultyValidator
{
    public class AddValidator : FluentValidation.AbstractValidator<Models.DTO.AddMethod.WalkDifficulty>
    {
        public AddValidator()
        {
            RuleFor(wd => wd.Code).NotEmpty();
        }
    }
    public class UpdateValidator : FluentValidation.AbstractValidator<Models.DTO.UpdateMethod.WalkDifficulty> 
    {
        public UpdateValidator()
        {
            RuleFor(wd => wd.Code).NotEmpty();
        }

    }
}
