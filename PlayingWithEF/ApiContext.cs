using Microsoft.EntityFrameworkCore;
using PlayingWithEF.Models;

namespace PlayingWithEF
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<PersonInstance> PersonInstances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonInstance>()
                .HasOne(p => p.Blob)
                .WithOne(p => p.PersonInstance)
                .HasForeignKey<Blob>(b => b.PersonInstanceId);

        }
    }
}