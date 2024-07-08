using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Comments;

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
}
