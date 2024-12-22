using FluentValidation;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using GameStore.WebApi.Controllers.GameControllers.Validators;

namespace GameStore.WebApi;

public static class ValidatorsInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateGameRequest>, CreateGameRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateGameRequestValidator>();
        return services;
    }
}
