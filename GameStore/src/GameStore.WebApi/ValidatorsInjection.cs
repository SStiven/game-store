using FluentValidation;
using GameStore.WebApi.Controllers.GameController.Dtos;
using GameStore.WebApi.Controllers.GameController.Validators;

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
