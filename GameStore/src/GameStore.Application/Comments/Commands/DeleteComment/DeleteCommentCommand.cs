using ErrorOr;

using MediatR;

namespace GameStore.Application.Comments.Commands.DeleteComment;
public record DeleteCommentCommand(string GameKey, Guid CommentId)
    : IRequest<ErrorOr<Deleted>>;
