using FluentValidation;
using GameStore.WebApi.Controllers.GameController.Dtos;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class GameDtoValidator : AbstractValidator<CreateGameDto>
{
    private const int MaxNameLength = 100;
    private const int MaxKeyLength = MaxNameLength + 5;
    private const int MaxDescriptionLength = 500;

    public GameDtoValidator()
    {
        RuleFor(g => g.Name).NotEmpty().Length(0, MaxNameLength);

        RuleFor(g => g.Key)
            .Must(key => key == null || key.Length <= MaxKeyLength)
            .WithMessage($"Key must be less than {MaxKeyLength} characters");

        RuleFor(g => g.Description).Length(0, MaxDescriptionLength);
    }
}