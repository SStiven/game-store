using FluentValidation;
using GameStore.WebApi.Controllers.GameControllers.Dtos;

namespace GameStore.WebApi.Controllers.GameControllers.Validators;

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

        RuleFor(g => g.Price).GreaterThan(0);

        RuleFor(g => g.UnitInStock).GreaterThan(0);

        RuleFor(g => g.Discount)
            .Must(discount => discount is > 0 and <= 100)
            .WithMessage("Discount must be between 0 and 100");
    }
}