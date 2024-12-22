using ErrorOr;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.Genres.Commands.DeleteGenre;

public class DeleteGenreCommandHandler(
    IGameRepository gameRepository,
    IGenreRepository genreRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGenreCommand, ErrorOr<Deleted>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id);
        if (genre is null)
        {
            return Error.NotFound(description: "Genre not found");
        }

        var games = await _gameRepository.GetByGenreIdAsync(request.Id);
        if (games.Count > 0)
        {
            return Error.Validation(description: "Genre is used in games");
        }

        var hasChildGenres = await _genreRepository.HasChildGenresAsync(request.Id);
        if (hasChildGenres)
        {
            return Error.Validation(description: "Genre has child genres");
        }

        await _genreRepository.RemoveAsync(genre);
        await _unitOfWork.SaveChangesAsync();

        return Result.Deleted;
    }
}