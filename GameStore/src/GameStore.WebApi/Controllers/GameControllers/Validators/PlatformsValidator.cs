using FluentValidation;
using GameStore.Application.Common.Interfaces;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class PlatformsValidator : AbstractValidator<IEnumerable<Guid>>
{
    public PlatformsValidator(IPlatformRepository platformRepository)
    {
        RuleFor(platforms => platforms)
            .NotNull()
            .Must(p => p != null && p.Any())
            .WithMessage("Platforms must contain at least one item")
            .Must(p => p.Count() <= 3)
            .WithMessage("Platforms must contain at most three items")
            .Must(p => p.Distinct().Count() == p.Count())
            .WithMessage("Platforms must contain unique items")
            .MustAsync(async (platformIds, cancellation) =>
            {
                return await platformRepository.AreAllPresentAsync(platformIds);
            })
            .WithMessage("Some platform ids do not exist");
    }
}
