using GameStore.Application.Publishers.Commands.CreatePublisher;
using GameStore.WebApi.Controllers.PublisherControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PublisherControllers;

[Route("publishers")]
public class PublishersController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreatePublisherRequest request)
    {
        var command = new CreatePublisherCommand(
            request.Publisher.CompanyName,
            request.Publisher.HomePage,
            request.Publisher.Description);

        var result = await _mediator.Send(command);
        return result.IsError ? Problem(result.Errors) : Ok(request);
    }
}
