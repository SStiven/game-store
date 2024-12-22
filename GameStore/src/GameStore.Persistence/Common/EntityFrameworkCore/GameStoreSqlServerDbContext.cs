using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Bans;
using GameStore.Domain.Comments;
using GameStore.Domain.Games;
using GameStore.Domain.Genres;
using GameStore.Domain.Orders;
using GameStore.Domain.Platforms;
using GameStore.Domain.Publishers;
using GameStore.Persistence.Comments.EntityFramworkCore;
using GameStore.Persistence.Games.EntityFrameworkCore;
using GameStore.Persistence.Genres.EntityFrameworkCore;
using GameStore.Persistence.Orders.EntityFrameworkCore;
using GameStore.Persistence.Platforms.EntityFrameworkCore;
using GameStore.Persistence.Publishers.EntityFrameworkCore;
using GameStore.Persistence.UserBans.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Common.EntityFrameworkCore;

public class GameStoreSqlServerDbContext(DbContextOptions<GameStoreSqlServerDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Comment> Comments { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<UserBan> UserBans { get; set; }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CommentConfiguration());

        modelBuilder.ApplyConfiguration(new GameConfiguration());

        modelBuilder.ApplyConfiguration(new GenreConfiguration());

        modelBuilder.ApplyConfiguration(new PlatformConfiguration());

        modelBuilder.ApplyConfiguration(new GameGenreConfiguration());

        modelBuilder.ApplyConfiguration(new GameGenreConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlatformConfiguration());

        modelBuilder.ApplyConfiguration(new PublisherConfiguration());

        modelBuilder.ApplyConfiguration(new OrderConfiguration());

        modelBuilder.ApplyConfiguration(new OrderGameConfiguration());

        modelBuilder.ApplyConfiguration(new UserBanConfiguration());

        modelBuilder.SeedDefaultPlaforms();

        modelBuilder.SeedDefaultGenres();
    }
}
