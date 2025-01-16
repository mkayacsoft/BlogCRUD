using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BlogCRUD.Services.ExceptionHandlers
{
    // IExceptionHandler arayüzünü uygulayan bir sınıf.
    internal class GlobalExceptionHandler : IExceptionHandler
    {
        // Hata durumunda çağrılan asenkron metot.
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Hata mesajını ve durum kodunu içeren bir ServiceResult nesnesi oluşturur.
            var errorsAsDto = ServiceResult.Failure(exception.Message, HttpStatusCode.InternalServerError);

            // HTTP yanıtının durum kodunu 500 (Internal Server Error) olarak ayarlar.
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // Yanıtın içerik türünü JSON olarak ayarlar.
            httpContext.Response.ContentType = "application/json";
            // Hata bilgilerini JSON formatında yanıt olarak yazar.
            await httpContext.Response.WriteAsJsonAsync(errorsAsDto, cancellationToken: cancellationToken);

            // Hatanın başarıyla işlendiğini belirtir.
            return true;
        }
    }
}
