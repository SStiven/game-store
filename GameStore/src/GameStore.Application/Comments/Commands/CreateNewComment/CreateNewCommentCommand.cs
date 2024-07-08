using ErrorOr;
using GameStore.Domain.Comments;

using MediatR;

namespace GameStore.Application.Comments.Commands.CreateNewComment;

public record CreateNewCommentCommand(
    string GameKey,
    string Name,
    string Body,
    Guid? ParentId) : IRequest<ErrorOr<Comment>>;
