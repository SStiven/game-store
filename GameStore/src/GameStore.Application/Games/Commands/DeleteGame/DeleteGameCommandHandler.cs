using ErrorOr;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.Games.Commands.DeleteGame;

public class DeleteGameCommandHandler(
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGameCommand, ErrorOr<Deleted>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdWithGenresAndPlatformsAsync(request.Id);

        if (game is null)
        {
            return Error.NotFound();
        }

        game.GameGenres.Clear();
        game.GamePlatforms.Clear();
        await _gameRepository.RemoveAsync(game);
        await _unitOfWork.SaveChangesAsync();

        return Result.Deleted;
    }
}