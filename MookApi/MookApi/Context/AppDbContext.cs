using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MookApi.Models;

namespace MookApi.Context
{
    public class AppDbContext : IdentityDbContext<Users, Roles, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Admins> Admins { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<RequestHeader> RequestHeader { get; set; }
        public DbSet<RequestDetails> RequestDetails { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Admins>().HasOne(b => b.AuthorsFk).WithMany().HasForeignKey("AdminID").OnDelete(DeleteBehavior.Restrict);
        }

    }
}
