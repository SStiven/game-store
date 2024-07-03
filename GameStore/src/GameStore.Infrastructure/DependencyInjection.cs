using GameStore.Application.Common.Interfaces;
using GameStore.Infrastructure.HttpClients.Payment;
using GameStore.Infrastructure.PdfSharpCoreGenerator;

using Microsoft.Extensions.DependencyInjection;

using Polly;
using Polly.Extensions.Http;

using Serilog;

namespace GameStore.Infrastructure.DateTimeServices;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ISystemClock, SystemClock>();

        Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level is Serilog.Events.LogEventLevel.Information)
                    .WriteTo.File("Logs/info-.txt", rollingInterval: RollingInterval.Day))
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(
                        e => e.Level is Serilog.Events.LogEventLevel.Error)
                    .WriteTo.File("Logs/error-.txt", rollingInterval: RollingInterval.Day))
                .CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        var paymentApiUrl = "http://localhost:5175";

        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500));

        services.AddHttpClient<IPaymentClient, PaymentClient>(client =>
        {
            client.BaseAddress = new Uri(paymentApiUrl);
        }).AddPolicyHandler(retryPolicy);

        services.AddScoped<IPdfGeneratorService, PdfSharpCoreGeneratorService>();

        return services;
    }
}
