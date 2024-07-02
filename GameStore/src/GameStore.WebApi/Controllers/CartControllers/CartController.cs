using GameStore.Application.Carts.Commands.AddGameToCart;
using GameStore.Application.Carts.Commands.RemoveGameFromCart;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.CartControllers;

[Route("games")]
public class CartController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpPost("{key}/buy")]
    public async Task<IActionResult> AddGame(string key)
    {
        var customerId = Guid.Empty;
        var result = await _mediator.Send(new AddGameToCartCommand(customerId, key));
        return result.IsError ? Problem(result.Errors) : Ok();
    }

    [HttpDelete("orders/cart/{key}")]
    public async Task<IActionResult> RemoveGame(string key)
    {
        var customerId = Guid.Empty;
        var result = await _mediator.Send(new DeleteGameFromCartCommand(customerId, key));
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
