using GameStore.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace GameStore.Infrastructure.DateTimeServices;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        return services;
    }
}
