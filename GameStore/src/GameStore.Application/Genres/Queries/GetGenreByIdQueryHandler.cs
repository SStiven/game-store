using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public class GetGenreByIdQueryHandler(IGenreRepository genreRepository)
    : IRequestHandler<GetGenreByIdQuery, ErrorOr<Genre>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;

    public async Task<ErrorOr<Genre>> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id);

        return genre is null
            ? Error.NotFound()
            : genre;
    }
}
