using ErrorOr;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.Platforms.Commands.DeletePlatform;

public class DeletePlatformCommandHandler(
    IPlatformRepository platformRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePlatformCommand, ErrorOr<Deleted>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _platformRepository.GetByIdAsync(request.Id);
        if (platform is null)
        {
            return Error.NotFound(description: "Platform not found");
        }

        var hasGames = await _gameRepository.HasGamesWithPlatformIdAsync(platform.Id);
        if (hasGames)
        {
            return Error.Validation(description: "Can't delete platform with games.");
        }

        await _platformRepository.RemoveAsync(platform);
        await _unitOfWork.SaveChangesAsync();
        return Result.Deleted;
    }
}
