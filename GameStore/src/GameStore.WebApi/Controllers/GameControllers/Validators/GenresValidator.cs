using FluentValidation;
using GameStore.Application.Common.Interfaces;

namespace GameStore.WebApi.Controllers.GameController.Validators;

public class GenresValidator : AbstractValidator<IEnumerable<Guid>>
{
    public GenresValidator(IGenreRepository genreRepository)
    {
        RuleFor(genres => genres)
            .NotNull()
            .Must(genres => genres != null && genres.Any())
            .WithMessage("Genres must contain at least one item")
            .Must(genres => genres.Count() <= 2)
            .WithMessage("Genres must contain at most two items")
            .Must(genres => genres.Distinct().Count() == genres.Count())
            .WithMessage("Genres must contain unique items")
            .MustAsync(async (genreIds, cancellation) =>
            {
                return await genreRepository.AreAllPresentAsync(genreIds);
            })
            .WithMessage("Some genre ids do not exist");
    }
}
