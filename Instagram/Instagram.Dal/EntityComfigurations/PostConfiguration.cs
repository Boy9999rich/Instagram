using Instagram.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram.Dal.EntityComfigurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(c => c.PostId);

        builder.Property(p => p.CreatedTime).IsRequired(true);

        builder.Property(p => p.PostType).IsRequired(true);

        builder.HasMany(c => c.Comments)
            .WithOne(b => b.Post)
            .HasForeignKey(b => b.PostId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}
