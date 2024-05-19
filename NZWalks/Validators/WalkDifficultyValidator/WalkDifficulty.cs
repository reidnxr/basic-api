using FluentValidation;

namespace Validators.WalkDifficultyValidator
{
    public class AddValidator : AbstractValidator<Models.DTO.AddMethod.WalkDifficulty>
    {
        public AddValidator()
        {
            RuleFor(wd => wd.Code).NotEmpty();
        }
    }
    public class UpdateValidator : AbstractValidator<Models.DTO.UpdateMethod.WalkDifficulty>
    {
        public UpdateValidator()
        {
            RuleFor(wd => wd.Code).NotEmpty();
        }

    }
}
