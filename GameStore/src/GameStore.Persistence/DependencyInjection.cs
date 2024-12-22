using GameStore.Application.Common.Interfaces;
using GameStore.Persistence.Carts;
using GameStore.Persistence.Comments.EntityFramworkCore;
using GameStore.Persistence.Common.EntityFrameworkCore;
using GameStore.Persistence.Common.InMemoryCache;
using GameStore.Persistence.Games.EntityFrameworkCore;
using GameStore.Persistence.Games.Filesystem;
using GameStore.Persistence.Games.MongoDb;
using GameStore.Persistence.Genres.EntityFrameworkCore;
using GameStore.Persistence.Orders.MongoDb;
using GameStore.Persistence.Platforms.EntityFrameworkCore;
using GameStore.Persistence.Publishers.EntityFrameworkCore;
using GameStore.Persistence.Shippers.MongoDb;
using GameStore.Persistence.UserBans.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

namespace GameStore.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("NorthwindMongoDbConnection")));
        services.AddScoped<IShippersRepository, MongoDbShippersRepository>();
        services.AddScoped<IReadOnlyOrderRepository, MongoDbOrderRepository>();
        services.AddScoped<IReadOnlyGameRespository, MongoDbGameRepository>();

        services.AddDbContext<GameStoreSqlServerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GameShopSqlServerConnection"));
        });

        services.AddScoped<ICacheService, InMemoryCacheService>();
        services.AddScoped<ICommentRepository, SqlServerCommentRepository>();
        services.AddScoped<IGameFileRepository, GameFileRespository>();
        services.AddScoped<IGameRepository, SqlServerGameRepository>();
        services.AddScoped<IGenreRepository, SqlServerGenreRepository>();
        services.AddScoped<IOrderRepository, SqlServerOrderRepository>();
        services.AddScoped<IPlatformRepository, SqlServerPlatformRepository>();
        services.AddScoped<IPublisherRepository, SqlServerPublisherRepository>();
        services.AddScoped<IUserBanRepository, SqlServerUserBanRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<GameStoreSqlServerDbContext>());
        services.AddMemoryCache();

        return services;
    }
}
