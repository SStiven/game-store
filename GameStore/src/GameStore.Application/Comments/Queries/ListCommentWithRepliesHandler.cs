using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;

using MediatR;

namespace GameStore.Application.Comments.Queries;
internal class ListCommentWithRepliesHandler(
    IGameRepository gameRepository,
    ICommentRepository commentsRepository)
    : IRequestHandler<ListCommentWithReplies, IEnumerable<Comment>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly ICommentRepository _commentsRepository = commentsRepository;

    public async Task<IEnumerable<Comment>> Handle(ListCommentWithReplies request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            var empty = Array.Empty<Comment>();
            return empty;
        }

        return await _commentsRepository.GetWithRepliesByGameIdAsync(game.Id);
    }
}
