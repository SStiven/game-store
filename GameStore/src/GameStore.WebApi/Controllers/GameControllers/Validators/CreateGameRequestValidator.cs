using FluentValidation;
using GameStore.Application.Common.Interfaces;
using GameStore.WebApi.Controllers.GameController.Dtos;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class CreateGameRequestValidator : AbstractValidator<CreateGameRequest>
{
    public CreateGameRequestValidator(
        IGenreRepository genreRepository,
        IPlatformRepository platformRepository)
    {
        RuleFor(r => r.Game).NotNull().SetValidator(new GameDtoValidator());

        RuleFor(r => r.Genres).SetValidator(new GenresValidator(genreRepository));

        RuleFor(r => r.Platforms).SetValidator(new PlatformsValidator(platformRepository));
    }
}
