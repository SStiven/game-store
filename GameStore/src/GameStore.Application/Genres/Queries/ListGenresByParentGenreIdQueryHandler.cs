using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public class ListGenresByParentGenreIdQueryHandler(IGenreRepository genreRepository)
    : IRequestHandler<ListGenresByParentGenreIdQuery, ErrorOr<IReadOnlyList<Genre>>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;

    public async Task<ErrorOr<IReadOnlyList<Genre>>> Handle(ListGenresByParentGenreIdQuery request, CancellationToken cancellationToken)
    {
        var parentGenre = await _genreRepository.GetByIdAsync(request.ParentGenreId);
        return parentGenre is null
            ? Error.Validation(description: "Parent genre with provided key not found")
            : await _genreRepository.GetByParentGenreIdAsync(request.ParentGenreId);
    }
}