using Microsoft.AspNetCore.Mvc;

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
                DateTimeOffset.Now);

        return Ok(response);
    }
}