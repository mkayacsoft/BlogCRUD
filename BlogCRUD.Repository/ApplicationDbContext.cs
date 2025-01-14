using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogCRUD.Repository
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Post.Post> Posts { get; set; } = default!; // <--- Add this property 3
        protected override void OnModelCreating(ModelBuilder modelBuilder) // <--- Add this method 1
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
