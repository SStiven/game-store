using System.Data;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;

using Microsoft.EntityFrameworkCore;

using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Comments.EntityFramworkCore;

public class SqlServerCommentRepository(GameStoreSqlServerDbContext context) : ICommentRepository
{
    private readonly GameStoreSqlServerDbContext _context = context;

    public async Task<Comment> AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        return comment;
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<IReadOnlyList<Comment>> GetWithRepliesByGameIdAsync(Guid gameId)
    {
        var comments = await _context.Comments
                                     .Where(c => c.GameId == gameId)
                                     .ToListAsync();

        var commentDictionary = comments.ToDictionary(c => c.Id);
        var rootComments = new List<Comment>();
        var noProcessedComments = new HashSet<Comment>(comments);

        foreach (var comment in noProcessedComments)
        {
            if (comment.ParentId == null)
            {
                rootComments.Add(comment);
                noProcessedComments.Remove(comment);
            }
        }

        foreach (var noProcessedComment in noProcessedComments)
        {
            var parentId = noProcessedComment.ParentId;

            if (parentId is null)
            {
                continue;
            }

            if (commentDictionary.TryGetValue((Guid)parentId, out var parentComment))
            {
                parentComment.AddReply(noProcessedComment);
            }
        }

        return rootComments;
    }
}