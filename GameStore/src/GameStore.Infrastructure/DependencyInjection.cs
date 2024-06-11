using GameStore.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Infrastructure.DateTimeServices;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();
        return services;
    }
}
