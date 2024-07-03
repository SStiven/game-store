using GameStore.WebApi.Controllers.OrderControllers.Dtos;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GameStore.WebApi.ModelBinders;

public class PaymentRequestModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType != typeof(PaymentRequest))
        {
            return null;
        }

        var subclasses = new[] { typeof(BankPaymentRequest), };

        var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
        foreach (var type in subclasses)
        {
            var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
            binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
        }

        return new PaymentRequestModelBinder(binders);
    }
}
