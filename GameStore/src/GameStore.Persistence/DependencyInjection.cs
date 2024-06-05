using GameStore.Application.Common.Interfaces;
using GameStore.Persistence.EntityFrameworkCore.Repositories;
using GameStore.Persistence.Games.EntityFrameworkCore;
using GameStore.Persistence.Games.Filesystem;
using GameStore.Persistence.Genres.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GameStoreSqlServerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GameShopSqlServerConnection"));
        });

        services.AddScoped<IGameRepository, SqlServerGameRepository>();
        services.AddScoped<IGenreRepository, SqlServerGenreRepository>();
        services.AddScoped<IPlatformRepository, SqlServerPlatformRepository>();
        services.AddScoped<IGameFileRepository, GameFileRespository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GameStoreSqlServerDbContext>());

        return services;
    }
}
