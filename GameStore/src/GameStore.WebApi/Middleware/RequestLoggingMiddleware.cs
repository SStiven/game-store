using System.Text;

using GameStore.Application.Common.Interfaces;

namespace GameStore.WebApi.Middleware;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger,
    ISystemClock systemClock)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;
    private readonly ISystemClock _systemClock = systemClock;

    public async Task Invoke(HttpContext context)
    {
        var startTime = _systemClock.UtcNow;

        var requestContent = await ReadRequestBody(context.Request);

        var originalResponseBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        var elapsedTime = _systemClock.UtcNow - startTime;
        var responseContent = await ReadResponseBody(responseBody);
        context.Response.Body = originalResponseBodyStream;

        var logDetails = new
        {
            UserIP = context.Connection.RemoteIpAddress?.ToString(),
            StartTime = startTime,
            ElapsedTime = elapsedTime,
            ResponseStatusCode = context.Response.StatusCode,
            RequestContent = requestContent,
            ResponseContent = responseContent,
        };

        _logger.LogInformation("Request: {@logDetails}", logDetails);

        await responseBody.CopyToAsync(originalResponseBodyStream);
    }

    private static async Task<string> ReadRequestBody(HttpRequest request)
    {
        request.EnableBuffering();
        request.Body.Position = 0;

        using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;

        return body;
    }

    private static async Task<string> ReadResponseBody(Stream responseBody)
    {
        responseBody.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(responseBody).ReadToEndAsync();
        responseBody.Seek(0, SeekOrigin.Begin);

        return text;
    }
}
