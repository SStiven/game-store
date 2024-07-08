using ErrorOr;
using GameStore.Domain.Comments;
using MediatR;

namespace GameStore.Application.Comments.Commands.ReplyToComment;

public record ReplyToCommentCommand(
        string GameKey,
        string Name,
        string Body,
        Guid? ParentId) : IRequest<ErrorOr<Comment>>;
