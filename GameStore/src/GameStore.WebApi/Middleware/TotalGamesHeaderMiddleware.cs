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
            var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
            int count = await mediator.Send(new GetCountGamesQuery());
            context.Response.Headers["x-total-numbers-of-games"] = count.ToString();
        }

        await _next(context);
    }
}
