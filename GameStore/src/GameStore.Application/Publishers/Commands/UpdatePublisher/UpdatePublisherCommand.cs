using ErrorOr;
using GameStore.Domain.Publishers;
using MediatR;

namespace GameStore.Application.Publishers.Commands.UpdatePublisher;

public record UpdatePublisherCommand(
    Guid Id,
    string CompanyName,
    string? HomePage,
    string? Description) : IRequest<ErrorOr<Publisher>>;