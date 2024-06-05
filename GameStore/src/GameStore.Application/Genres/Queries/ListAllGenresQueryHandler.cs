using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public class ListAllGenresQueryHandler(IGenreRepository genreRepository) : IRequestHandler<ListAllGenresQuery, IReadOnlyList<Genre>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;

    public async Task<IReadOnlyList<Genre>> Handle(ListAllGenresQuery request, CancellationToken cancellationToken)
    {
        return await _genreRepository.GetAllAsync();
    }
}