using ErrorOr;
using GameStore.Domain.Publishers;
using MediatR;

namespace GameStore.Application.Publishers.Commands.CreatePublisher;

public record CreatePublisherCommand(
    string CompanyName,
    string? HomePage,
    string? Description) : IRequest<ErrorOr<Publisher>>;