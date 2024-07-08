using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;
using MediatR;

namespace GameStore.Application.Comments.Commands.ReplyToComment;

public class ReplyToCommentCommandHandler(
    ICommentRepository commentsRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ReplyToCommentCommand, ErrorOr<Comment>>
{
    private readonly ICommentRepository _commentsRepository = commentsRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Comment>> Handle(ReplyToCommentCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound(description: "Game not found.");
        }

        if (!request.ParentId.HasValue)
        {
            return Error.Validation(description: "ParentId is required for reply action.");
        }

        var parentComment = await _commentsRepository.GetByIdAsync(request.ParentId.Value);
        if (parentComment is null)
        {
            return Error.NotFound(description: "Parent comment not found.");
        }

        var comment = new Comment(
            request.Name,
            $"[{parentComment.Name}], {request.Body}",
            request.ParentId,
            game.Id);

        await _commentsRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return comment;
    }
}