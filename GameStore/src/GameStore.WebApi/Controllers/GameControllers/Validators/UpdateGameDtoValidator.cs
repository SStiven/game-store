using FluentValidation;
using GameStore.WebApi.Controllers.GameControllers.Dtos;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class UpdateGameDtoValidator : AbstractValidator<UpdateGameDto>
{
    private const int MaxNameLength = 100;
    private const int MaxKeyLength = MaxNameLength + 5;

    public UpdateGameDtoValidator()
    {
        RuleFor(g => g.Name).NotEmpty().Length(0, MaxNameLength);

        RuleFor(g => g.Key)
            .Must(key => key == null || key.Length <= MaxKeyLength)
            .WithMessage($"Key must be less than {MaxKeyLength} characters");

        RuleFor(g => g.Description).Length(0, 1000);

        RuleFor(g => g.Price).GreaterThan(0);

        RuleFor(g => g.UnitInStock).GreaterThan(0);

        RuleFor(g => g.Discount)
            .Must(discount => discount is > 0 and < 100)
            .WithMessage("Discount must be between 0 and 100");
    }
}