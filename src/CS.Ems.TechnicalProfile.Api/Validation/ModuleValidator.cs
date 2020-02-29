using CS.Ems.Domain.Entities;
using FluentValidation;

namespace CS.Ems.Profile.Api.Validation
{
    public class ModuleValidator : AbstractValidator<Module>
    {
        public ModuleValidator()
        {
            RuleFor(module => module.Name)
                .NotNull()
                .WithMessage("Name cannot be null")
                .MinimumLength(3)
                .WithMessage("Name too short. Needs to be greater than 2 characters")
                .MaximumLength(50)
                .WithMessage("Description too long. Needs to be at maximum 50 characters");

            RuleFor(module => module.Description)
                .NotNull()
                .WithMessage("Description cannot be null")
                .MinimumLength(3)
                .WithMessage("Description too short. Needs to be greater then 3 characters")
                .MaximumLength(100)
                .WithMessage("Description too long. Needs to be at maximum 100 characters");
        }
    }
}
