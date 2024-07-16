using ErrorOr;

using GameStore.Application.Common.Interfaces;

using MediatR;

namespace GameStore.Application.Comments.Commands.DeleteComment;
public class DeleteCommentCommandHandler(
    IGameRepository gameRepository,
    ICommentRepository commentRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCommentCommand, ErrorOr<Deleted>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly ICommentRepository _commentRepository = commentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound("Game not found.");
        }

        var comments = await _commentRepository.GetWithRepliesByGameIdAsync(game.Id);
        if (comments.Count == 0)
        {
            return Error.NotFound("Comment not found.");
        }

        var comment = comments.FirstOrDefault(c => c.Id == request.CommentId);
        if (comment is null)
        {
            return Error.NotFound("Comment not found.");
        }

        comment.Delete();

        await _commentRepository.UpdateAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Deleted;
    }
}
