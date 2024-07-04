using System.Text.Json;
using System.Text.Json.Nodes;

using GameStore.WebApi.Controllers.OrderControllers.Dtos;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameStore.WebApi.ModelBinders;

public class PaymentRequestModelBinder : IModelBinder
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        using var sr = new StreamReader(bindingContext.HttpContext.Request.Body);
        var json = await sr.ReadToEndAsync();
        var jsonNode = JsonNode.Parse(json).AsObject();
        var method = jsonNode["method"]?.ToString();

        PaymentRequest? payment = null;
        if (method == "Bank")
        {
            payment = JsonSerializer.Deserialize<BankPaymentRequest>(json, _options);
        }
        else if (method == "IBox terminal")
        {
            payment = JsonSerializer.Deserialize<IBoxTerminalPaymentRequest>(json, _options);
        }
        else if (method == "Visa")
        {
            payment = JsonSerializer.Deserialize<VisaPaymentRequest>(json, _options);
        }
        else
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        bindingContext.Result = ModelBindingResult.Success(payment);
    }
}
