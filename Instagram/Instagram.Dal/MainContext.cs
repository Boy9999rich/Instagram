using Instagram.Dal.Entity;
using Instagram.Dal.EntityComfigurations;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Dal;

public class MainContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountComfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
    }
}
