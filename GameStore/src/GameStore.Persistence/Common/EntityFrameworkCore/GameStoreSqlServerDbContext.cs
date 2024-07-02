using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using GameStore.Domain.Genres;
using GameStore.Domain.Orders;
using GameStore.Domain.Platforms;
using GameStore.Domain.Publishers;
using GameStore.Persistence.EntityFrameworkCore.Configurations;
using GameStore.Persistence.EntityFrameworkCore.Seeders;
using GameStore.Persistence.Games.EntityFrameworkCore;
using GameStore.Persistence.Genres.EntityFrameworkCore;
using GameStore.Persistence.Orders.EntityFrameworkCore;
using GameStore.Persistence.Publishers.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

public class GameStoreSqlServerDbContext(DbContextOptions<GameStoreSqlServerDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new GameConfiguration());

        modelBuilder.ApplyConfiguration(new GenreConfiguration());

        modelBuilder.ApplyConfiguration(new PlatformConfiguration());

        modelBuilder.ApplyConfiguration(new GameGenreConfiguration());

        modelBuilder.ApplyConfiguration(new GameGenreConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlatformConfiguration());

        modelBuilder.ApplyConfiguration(new PublisherConfiguration());

        modelBuilder.ApplyConfiguration(new OrderConfiguration());

        modelBuilder.ApplyConfiguration(new OrderGameConfiguration());

        modelBuilder.SeedDefaultPlaforms();

        modelBuilder.SeedDefaultGenres();
    }
}
