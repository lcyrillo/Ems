using FluentValidation;

namespace CS.Ems.TechnicalProfile.Api
{
    public class TechnicalProfileValidator : AbstractValidator<Domain.Entities.TechnicalProfile>
    {
        public TechnicalProfileValidator()
        {
            RuleFor(profile => profile.Name)
                .NotNull()
                .WithMessage("Name cannot be null")
                .MinimumLength(3)
                .WithMessage("Name too short. Needs to be greater than 2 characters")
                .MaximumLength(20)
                .WithMessage("Name too long. Needs to be at maximum 20 characters");


            RuleFor(profile => profile.Description)
                .NotNull()
                .WithMessage("Description cannot be null")
                .MinimumLength(3)
                .WithMessage("Description too short. Needs to be greater then 3 characters")
                .MaximumLength(30)
                .WithMessage("Description too long. Needs to be at maximum 30 characters");
        }
    }
}
