using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.UpdateGame;

public class UpdateGameCommandHandler(
    IGameRepository gameRepository,
    IGenreRepository genreRepository,
    IPlatformRepository platformRepository,
    IPublisherRepository publisherRepository,
    IGameFileRepository gameFileRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateGameCommand, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IPublisherRepository _publisherRepository = publisherRepository;
    private readonly IGameFileRepository _gameFileRepository = gameFileRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Game>> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdWithGenresAndPlatformsAsync(request.Id);
        if (game == null)
        {
            return Error.NotFound($"The game with id {request.Id} was not found");
        }

        var areAllGenresPrensent = await _genreRepository.AreAllPresentAsync(request.GenreIds);
        if (!areAllGenresPrensent)
        {
            return Error.Validation("Some genres don't exist");
        }

        var allPlatformsPresent = await _platformRepository.AreAllPresentAsync(request.PlatformIds);
        if (!allPlatformsPresent)
        {
            return Error.Validation("Some platforms don't exist");
        }

        var publisher = await _publisherRepository.GetByIdAsync(request.PublisherId);
        if (publisher is null)
        {
            return Error.Validation(description: "Publisher doesn't exist");
        }

        game.Update(
            request.Name,
            request.Key,
            request.Description,
            request.Price,
            request.UnitInStock,
            request.Discount,
            request.GenreIds,
            request.PlatformIds,
            publisher);

        await _gameFileRepository.SaveGameFileAsync(game);

        await _gameRepository.Update(game);
        await _unitOfWork.SaveChangesAsync();

        return game;
    }
}