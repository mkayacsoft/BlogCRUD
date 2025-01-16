using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogCRUD.Services
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        // OnActionExecutionAsync metodu, eylem yöntemi çalıştırılmadan önce çağrılır.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Model durumu geçerli değilse, hata mesajlarını toplar.
            if (!context.ModelState.IsValid)
            {
                // ModelState'deki hata mesajlarını alır.
                var errors = context.ModelState.Values.SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage).ToList();

                // Hata mesajları ile bir sonuç modeli oluşturur.
                var resultModel = ServiceResult.Failure(errors);
                // Hata durumunda, BadRequest (400) yanıtı döner.
                context.Result = new BadRequestObjectResult(resultModel);
                return;
            }
            // Eylem yöntemini çalıştırmaya devam eder.
            await next();
        }
    }
}
