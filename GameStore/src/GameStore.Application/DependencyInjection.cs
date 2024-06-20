using ErrorOr;
using FluentValidation;

using GameStore.Application.Games.Commands.CreateGame;
using GameStore.Application.Publishers.Commands.CreatePublisher;
using GameStore.Application.Publishers.Commands.UpdatePublisher;
using GameStore.Domain.Games;
using GameStore.Domain.Publishers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

            options.AddBehavior<
                IPipelineBehavior<CreatePublisherCommand, ErrorOr<Publisher>>,
                CreatePublisherCommandBehavior>();
            options.AddBehavior<
                IPipelineBehavior<UpdatePublisherCommand, ErrorOr<Publisher>>,
                UpdatePublisherCommandBehavior>();
            options.AddBehavior<
                IPipelineBehavior<CreateGameCommand, ErrorOr<Game>>,
                CreateGameCommandBehavior>();
        });

        services.AddValidatorsFromAssemblyContaining<CreatePublisherCommandValidator>();

        return services;
    }
}
