using Instagram.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram.Dal.EntityComfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment");

        builder.HasKey(b => b.CommentId);

        builder.Property(b => b.Body).IsRequired().HasMaxLength(200);

        builder.Property(b => b.CreatedTime).IsRequired(true);

        builder.HasOne(b => b.ParentComment).WithMany(v => v.Replies)
            .HasForeignKey(b => b.ParentCommentId).OnDelete(DeleteBehavior.NoAction);
    }
}
