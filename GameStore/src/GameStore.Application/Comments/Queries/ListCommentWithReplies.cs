using GameStore.Domain.Comments;

using MediatR;

namespace GameStore.Application.Comments.Queries;

public record ListCommentWithReplies(string GameKey) : IRequest<IEnumerable<Comment>>;