using FluentValidation;

namespace GameStore.Application.Games.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    private const int MaxNameLength = 100;
    private const int MaxKeyLength = MaxNameLength + 5;
    private const int MaxDescriptionLength = 500;

    public CreateGameCommandValidator()
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

        RuleFor(g => g.GenreIds)
            .NotNull()
            .Must(genres => genres != null && genres.Any())
            .WithMessage("Genres must contain at least one item")
            .Must(genres => genres.Count() <= 2)
            .WithMessage("Genres must contain at most two items")
            .Must(genres => genres.Distinct().Count() == genres.Count())
            .WithMessage("Genres must contain unique items");

        RuleFor(r => r.PlatformIds)
            .NotNull()
            .Must(p => p != null && p.Any())
            .WithMessage("Platforms must contain at least one item")
            .Must(p => p.Count() <= 3)
            .WithMessage("Platforms must contain at most three items")
            .Must(p => p.Distinct().Count() == p.Count())
            .WithMessage("Platforms must contain unique items");
    }
}
