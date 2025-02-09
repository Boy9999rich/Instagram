using Instagram.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagram.Dal.EntityComfigurations;

public class AccountComfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");

        builder.HasKey(c => c.AccountId);

        builder.Property(b => b.UserName).IsRequired(true).HasMaxLength(50);

        builder.HasIndex(b => b.UserName).IsUnique(true);

        builder.HasMany(b => b.Posts).WithOne(n => n.Account).HasForeignKey(b => b.AccountId);

        builder.HasMany(c => c.Comments).WithOne(b => b.Account).HasForeignKey(b => b.AccountId);
    }
}
