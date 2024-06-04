using FluentValidation;
using GameStore.WebApi.Controllers.GameController.Dtos;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class CreateGameRequestValidator : AbstractValidator<CreateGameRequest>
{
    public CreateGameRequestValidator()
    {
        RuleFor(r => r.Game).NotNull().SetValidator(new GameDtoValidator());

        RuleFor(r => r.Genres).SetValidator(new GenresValidator());

        RuleFor(r => r.Platforms).SetValidator(new PlatformsValidator());
    }
}
