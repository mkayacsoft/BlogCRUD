using BlogCRUD.Services.ExceptionHandlers;
using BlogCRUD.Services.Post;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogCRUD.Services.Extensions
{
    public static class ServiceExtension
    {

        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IPostService,PostService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            return services;
        }
    }
}
