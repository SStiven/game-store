using GameStore.Application.Carts.Queries;
using GameStore.Application.Orders.Command.PayCartWirhIBoxTerminal;
using GameStore.Application.Orders.Command.PayCartWithBank;
using GameStore.Application.Orders.Queries;
using GameStore.WebApi.Controllers.OrderControllers.Dtos;
using GameStore.WebApi.ModelBinders;

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
            order => Ok(new OrderResponse(
                order.Id,
                order.CustomerId,
                order.Date)),
            Problem);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetOrderDetail(Guid id)
    {
        var result = await _mediator.Send(new GetOrderDetailsByIdQuery(id));
        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        var orderGames = result.Value.Select(og => new OrderDetailResponse(
            og.ProductId,
            og.Price,
            og.Quantity,
            og.Discount is null ? 0 : og.Discount.Value));

        return Ok(orderGames);
    }

    [HttpGet("cart")]
    public async Task<IActionResult> GetCart()
    {
        var result = await _mediator.Send(new GetCartQuery());
        if (result.IsError)
        {
            return Problem(result.Errors);
        }

        var cart = result.Value.Select(og => new OrderDetailResponse(
            og.ProductId,
            og.Price,
            og.Quantity,
            og.Discount is null ? 0 : og.Discount.Value));

        return Ok(cart);
    }

    [HttpPost("payment")]
    public async Task<IActionResult> MakeVisaPayment(
        [ModelBinder(BinderType = typeof(PaymentRequestModelBinder))] PaymentRequest paymentRequest)
    {
        if (paymentRequest is BankPaymentRequest bankPaymentRequest)
        {
            var result = await _mediator.Send(new PayCartWithBankCommand());
            return result.Match(
                bytes => File(bytes, "application/octet-stream", "invoice.pdf"),
                Problem);
        }

        if (paymentRequest is IBoxTerminalPaymentRequest iBoxTerminalPaymentRequest)
        {
            var result = await _mediator.Send(new PayCartWithIBoxTerminalCommand());
            return result.Match(
                Ok,
                Problem);
        }

        return Problem();
    }

    [HttpGet("payment-methods")]
    public async Task<IActionResult> GetPaymentMethods()
    {
        var result = await _mediator.Send(new ListPaymentMethodsQuery());
        return Ok(result.Select(
            pm => new PaymentMethodResult(
                pm.ImageUrl,
                pm.Name,
                pm.Description)));
    }
}