using FluentValidation;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class PlatformsValidator : AbstractValidator<IEnumerable<Guid>>
{
    public PlatformsValidator()
    {
        RuleFor(platforms => platforms)
            .NotNull()
            .Must(p => p != null && p.Any())
            .WithMessage("Platforms must contain at least one item")
            .Must(p => p.Count() <= 3)
            .WithMessage("Platforms must contain at most three items")
            .Must(p => p.Distinct().Count() == p.Count())
            .WithMessage("Platforms must contain unique items");
    }
}
