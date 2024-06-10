using GameStore.WebApi.Middleware;

namespace GameStore.WebApi.Extensions;

public static class TotalGamesHeaderMiddlewareExtensions
{
    public static IApplicationBuilder UseTotalGamesHeader(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TotalGamesHeaderMiddleware>();
    }
}
