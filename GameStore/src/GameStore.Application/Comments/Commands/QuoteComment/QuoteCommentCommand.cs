using ErrorOr;
using GameStore.Domain.Comments;
using MediatR;

namespace GameStore.Application.Comments.Commands.QuoteComment;

public record QuoteCommentCommand(
        string GameKey,
        string Name,
        string Body,
        Guid? ParentId) : IRequest<ErrorOr<Comment>>;