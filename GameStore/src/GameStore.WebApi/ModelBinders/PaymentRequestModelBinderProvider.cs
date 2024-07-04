using GameStore.WebApi.Controllers.OrderControllers.Dtos;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameStore.WebApi.ModelBinders;

public class PaymentRequestModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Metadata.ModelType != typeof(PaymentRequest)
            ? null
            : new PaymentRequestModelBinder();
    }
}