using GameStore.Application.Publishers.Commands.CreatePublisher;
using GameStore.Application.Publishers.Commands.DeletePublisher;
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
        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        var publisher = new PublisherResponse(
            result.Value.Id,
            result.Value.CompanyName,
            result.Value.HomePage,
            result.Value.Description);

        return Ok(publisher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeletePublisherCommand(id);
        var result = await _mediator.Send(command);

        return result.Match(
                    _ => NoContent(),
                    Problem);
    }
}
