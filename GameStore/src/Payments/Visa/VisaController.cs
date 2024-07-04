using Microsoft.AspNetCore.Mvc;
using Payments.Visa.Dtos;

namespace Payments.Visa;

[ApiController]
[Route("visa")]
public class VisaController : ControllerBase
{
    private static readonly Random Random = new();

    [HttpPost]
    public IActionResult ProcessPayment(PayWithVisaRequest visaPaymentRequest)
    {
        if (visaPaymentRequest.Model.CardNumber.Length != 16)
        {
            return BadRequest("Visa card number must have 16 digits");
        }

        int rand = Random.Next(1, 101);

        return rand <= 30
            ? StatusCode(500, "Internal Server Error")
            : Ok();
    }
}