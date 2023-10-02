using RBProducts.Common.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace RBProducts.Endpoint.WebAPI.Utils
{
    public static class ModelStateExtensions
    {
        public static OperationResultDto<List<Exception>> GetErrorResult(this ModelStateDictionary ms)
        {
            List<Exception> _errors = ms.SelectMany((s) => s.Value.Errors.Select(e=> new Exception($"خطا در فیلد {s.Key} با مقدار {s.Value.RawValue} : {e.ErrorMessage}"))).ToList();
            return new OperationResultDto<List<Exception>>() { IsSuccess = false, Message = "", Result = _errors };
        }
    }
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new OkObjectResult(context.ModelState.GetErrorResult());
                await next();
            }
            else {
            }
        }
    }
}
