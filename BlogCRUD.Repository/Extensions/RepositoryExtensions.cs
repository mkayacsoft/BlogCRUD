
using BlogCRUD.Repository.Categories;
using BlogCRUD.Repository.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace BlogCRUD.Repository.Extensions
{
    public static class RepositoryExtensions // <--- Add this class 7
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) // <--- Add this method 8
        {
           services.AddDbContext<ApplicationDbContext>(options =>
           {
               var connectionStringOption = configuration.GetSection("ConnectionStrings").Get<ConnectionStringOption>();
               options.UseNpgsql(connectionStringOption!.DefaultConnection, postgresqlserverAction =>
               {
                   postgresqlserverAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
               });
           });

           services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           services.AddScoped<IPostRepository, PostRepository>();
           services.AddScoped<ICategoryRepository, CategoryRepository>();
           services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
