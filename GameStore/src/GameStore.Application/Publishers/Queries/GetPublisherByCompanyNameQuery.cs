using ErrorOr;

using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;

public record GetPublisherByCompanyNameQuery(string CompanyName) : IRequest<ErrorOr<Publisher>>;