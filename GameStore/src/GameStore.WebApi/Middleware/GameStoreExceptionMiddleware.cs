using Microsoft.AspNetCore.Diagnostics;

namespace GameStore.WebApi.Middleware;

public class GameStoreExceptionMiddleware(ILogger<GameStoreExceptionMiddleware> logger) : IMiddleware
{
    private readonly ILogger<GameStoreExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>()
            ?? throw new NotSupportedException();

        var exception = exceptionHandlerPathFeature.Error;

        var exceptionDetails = new
        {
            ExceptionType = exception.GetType().Name,
            ExceptionMessage = exception.Message,
            InnerExceptions = GetInnerExceptions(exception),
            StackTrace = exception.StackTrace,
        };

        _logger.LogError(exception, "An error occurred: {@ExceptionDetails}", exceptionDetails);

        await context.Response.WriteAsJsonAsync(new
        {
            Error = "We are having issues right now, if the problem persists contact with technical support.",
        });

        await next(context);
    }

    private static List<string> GetInnerExceptions(Exception exception)
    {
        var innerExceptions = new List<string>();

        while (exception.InnerException != null)
        {
            innerExceptions.Add(exception.InnerException.Message);
            exception = exception.InnerException;
        }

        return innerExceptions;
    }
}
