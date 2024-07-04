using Microsoft.AspNetCore.Mvc;
using Payments.IBoxTerminal.Dtos;

namespace Payments.IBoxTerminal;

[ApiController]
[Route("ibox-terminal")]
public class IBoxTerminalController : ControllerBase
{
    private static readonly Random Random = new();

    [HttpPost]
    public IActionResult ProcessPayment([FromBody] PayWithIBoxTerminalRequest payWithIBoxTerminalRequest)
    {
        int rand = Random.Next(1, 101);

        if (rand <= 30)
        {
            return StatusCode(500, "Internal Server Error");
        }

        if (rand <= 60)
        {
            return BadRequest();
        }

        var response = new PayWithIBoxTerminalResponse(
                payWithIBoxTerminalRequest.UserId,
                payWithIBoxTerminalRequest.Amount,
                DateTime.UtcNow);

        return Ok(response);
    }
}