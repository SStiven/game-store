using FluentValidation;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class GenresValidator : AbstractValidator<IEnumerable<Guid>>
{
    public GenresValidator()
    {
        RuleFor(genres => genres)
            .NotNull()
            .Must(genres => genres != null && genres.Any())
            .WithMessage("Genres must contain at least one item")
            .Must(genres => genres.Count() <= 2)
            .WithMessage("Genres must contain at most two items")
            .Must(genres => genres.Distinct().Count() == genres.Count())
            .WithMessage("Genres must contain unique items");
    }
}
