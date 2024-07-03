using GameStore.WebApi.Controllers.OrderControllers.Dtos;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GameStore.WebApi.ModelBinders;

public class PaymentRequestModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders) : IModelBinder
{
    private readonly Dictionary<Type, (ModelMetadata, IModelBinder)> _binders = binders;

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(PaymentRequest.Method));
        var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

        IModelBinder modelBinder;
        ModelMetadata modelMetadata;
        if (modelTypeValue == "Bank")
        {
            (modelMetadata, modelBinder) = _binders[typeof(BankPaymentRequest)];
        }
        else if (modelTypeValue == "IBox terminal")
        {
            (modelMetadata, modelBinder) = _binders[typeof(IBoxTerminalPaymentRequest)];
        }
        else
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
            bindingContext.ActionContext,
            bindingContext.ValueProvider,
            modelMetadata,
            bindingInfo: null,
            bindingContext.ModelName);

        await modelBinder.BindModelAsync(newBindingContext);
        bindingContext.Result = newBindingContext.Result;

        if (newBindingContext.Result.IsModelSet && newBindingContext.Result.Model != null)
        {
            bindingContext.ValidationState[newBindingContext.Result.Model] = new ValidationStateEntry
            {
                Metadata = modelMetadata,
            };
        }
    }
}
