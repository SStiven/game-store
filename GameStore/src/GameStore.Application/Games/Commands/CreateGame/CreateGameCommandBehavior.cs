using ErrorOr;

using FluentValidation;

using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Commands.CreateGame;

public class CreateGameCommandBehavior(IValidator<CreateGameCommand> validator)
    : IPipelineBehavior<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IValidator<CreateGameCommand> _validator = validator;

    public async Task<ErrorOr<Game>> Handle(
        CreateGameCommand request,
        RequestHandlerDelegate<ErrorOr<Game>> next,
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
