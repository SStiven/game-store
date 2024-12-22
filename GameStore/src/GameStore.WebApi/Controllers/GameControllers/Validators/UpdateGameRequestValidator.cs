using FluentValidation;
using GameStore.WebApi.Controllers.GameControllers.Dtos;

namespace GameStore.WebApi.Controllers.GameControllers.Validators;

public class UpdateGameRequestValidator : AbstractValidator<UpdateGameRequest>
{
    public UpdateGameRequestValidator()
    {
        RuleFor(r => r.Game).NotNull().SetValidator(new UpdateGameDtoValidator());

        RuleFor(r => r.Genres).SetValidator(new GenresValidator());

        RuleFor(r => r.Platforms).SetValidator(new PlatformsValidator());
    }
}
