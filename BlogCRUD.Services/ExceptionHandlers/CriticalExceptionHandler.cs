using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogCRUD.Services.ExceptionHandlers
{
    // CriticalExceptionHandler sınıfı, kritik istisnaları yakalamak ve işlemek için kullanılır.
    // IExceptionHandler arayüzünü uygular ve TryHandleAsync metodunu içerir.
    // Bu metod, bir HttpContext ve bir Exception alır ve eğer istisna CriticalException türündeyse,
    // konsola "Critical Exception" mesajını yazdırır. 
    // Metod, işlenip işlenmediğini belirtmek için false döner.
    //false döndüğü için bir sonra ki middleware e gönderir yani bizim yazdığımız global handlera yönlendirir.
    public class CriticalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is CriticalException)
            {
                Console.WriteLine("Critical Exception");
            }
            return ValueTask.FromResult(false);
        }
    }
}
