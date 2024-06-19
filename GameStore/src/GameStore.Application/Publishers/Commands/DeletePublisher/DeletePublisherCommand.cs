using ErrorOr;
using MediatR;

namespace GameStore.Application.Publishers.Commands.DeletePublisher;
public record DeletePublisherCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
