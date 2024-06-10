namespace GameStore.WebApi.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection UseCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAllOriginsMethodsHeaders",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithExposedHeaders("x-total-numbers-of-games");
                });
        });

        return services;
    }
}
