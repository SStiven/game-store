using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Queries;
using MediatR;

namespace GameStore.WebApi.Middleware;

public class TotalGamesHeaderMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Get)
        {
            using var scope = context.RequestServices.CreateScope();
            var cacheService = scope.ServiceProvider.GetService<ICacheService>();

            int count = 0;
            if (cacheService.Has<int>(nameof(GetCountGamesQuery)))
            {
                count = cacheService.Get<int>(nameof(GetCountGamesQuery));
            }
            else
            {
                var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
                count = await mediator.Send(new GetCountGamesQuery());
                cacheService.AddOrUpdate(nameof(GetCountGamesQuery), count);
            }

            context.Response.Headers["x-total-numbers-of-games"] = count.ToString();
        }

        await _next(context);
    }
}
