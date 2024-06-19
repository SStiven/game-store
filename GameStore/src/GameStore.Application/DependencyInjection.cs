using ErrorOr;
using FluentValidation;

using GameStore.Application.Common.Behaviors;
using GameStore.Application.Publishers.Commands.CreatePublisher;
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
        });

        services.AddValidatorsFromAssemblyContaining<CreatePublisherCommandValidator>();

        return services;
    }
}
