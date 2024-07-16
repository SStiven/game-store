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
            .Include(c => c.ParentComment)
            .ToListAsync();

        var rootComments = comments.Where(c => c.ParentId is null).ToList();

        return rootComments;
    }

    public Task UpdateAsync(Comment comment)
    {
        _context.Update(comment);
        return Task.CompletedTask;
    }
}