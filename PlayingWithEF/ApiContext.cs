using Microsoft.EntityFrameworkCore;

namespace PlayingWithEF
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Post)
                .WithOne(p => p.User)
                .HasForeignKey<Post>(p => p.UserId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithOne(u => u.Post)
                .HasForeignKey<User>(u => u.PostId);
        }
    }
}