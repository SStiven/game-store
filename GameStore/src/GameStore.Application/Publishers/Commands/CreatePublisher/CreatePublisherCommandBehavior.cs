using ErrorOr;

using FluentValidation;

using GameStore.Application.Publishers.Commands.CreatePublisher;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Common.Behaviors;

public class CreatePublisherCommandBehavior(IValidator<CreatePublisherCommand> validator)
    : IPipelineBehavior<CreatePublisherCommand, ErrorOr<Publisher>>
{
    private readonly IValidator<CreatePublisherCommand> _validator = validator;

    public async Task<ErrorOr<Publisher>> Handle(
        CreatePublisherCommand request,
        RequestHandlerDelegate<ErrorOr<Publisher>> next,
        CancellationToken cancellationToken)
    {
        var result = await _validator.ValidateAsync(request, cancellationToken);

        return result.IsValid
            ? await next()
            : result.Errors
                .ConvertAll(e => Error.Validation(description: e.ErrorMessage))
                .ToList();
    }
}
