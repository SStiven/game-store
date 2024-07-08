using GameStore.Domain.Comments;

namespace GameStore.Application.Common.Interfaces;

public interface ICommentRepository
{
    Task<Comment> AddAsync(Comment comment);

    Task<Comment?> GetByIdAsync(Guid id);

    Task<IReadOnlyList<Comment>> GetWithRepliesByGameIdAsync(Guid gameId);
}
