using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.CreateGame;

public class CreateGameCommand : IRequest<ErrorOr<Game>>
{
    public string Name { get; set; }

    public string Key { get; set; }

    public string? Description { get; set; }

    public IEnumerable<Guid> GenreIds { get; set; }

    public IEnumerable<Guid> PlatformIds { get; set; }
}
