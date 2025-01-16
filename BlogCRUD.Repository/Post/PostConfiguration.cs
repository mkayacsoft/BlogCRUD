using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogCRUD.Repository.Post
{
    public class PostConfiguration : IEntityTypeConfiguration<Post> // <--- Add this class 4
    {
        public void Configure(EntityTypeBuilder<Post> builder) // <--- Add this method 5
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Content).IsRequired().HasMaxLength(500);
            
        }
    }
}
