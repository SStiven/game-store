using GameStore.Application.Orders.Queries;
using GameStore.WebApi.Controllers.OrderControllers.Dtos;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.OrderControllers;

[Route("orders")]
public class OrderController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> ListAllPaidOrCancelledOrders()
    {
        var result = await _mediator.Send(new ListAllPaidOrCancelledOrders());

        return Ok(result.Select(o => new
        {
            o.Id,
            o.CustomerId,
            o.Date,
        }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery(id));

        return result.Match(
            order => Ok(new SimpleOrderResponse(
                order.Id,
                order.CustomerId,
                order.Date)),
            Problem);
    }
}
