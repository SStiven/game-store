using ErrorOr;
using FluentValidation;
using GameStore.Domain.Publishers;
using MediatR;

namespace GameStore.Application.Publishers.Commands.UpdatePublisher;

public class UpdatePublisherCommandBehavior(IValidator<UpdatePublisherCommand> validator)
    : IPipelineBehavior<UpdatePublisherCommand, ErrorOr<Publisher>>
{
    private readonly IValidator<UpdatePublisherCommand> _validator = validator;

    public async Task<ErrorOr<Publisher>> Handle(
        UpdatePublisherCommand request,
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
