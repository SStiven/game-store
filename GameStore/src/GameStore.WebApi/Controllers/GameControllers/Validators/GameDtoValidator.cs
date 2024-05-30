using FluentValidation;
using GameStore.WebApi.Controllers.GameController.Dtos;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class GameDtoValidator : AbstractValidator<CreateGameDto>
{
    public GameDtoValidator()
    {
        RuleFor(g => g.Name).NotEmpty().Length(0, 100);

        RuleFor(g => g.Key).NotEmpty().Length(0, 100);

        RuleFor(g => g.Description).NotEmpty().Length(0, 1000);
    }
}