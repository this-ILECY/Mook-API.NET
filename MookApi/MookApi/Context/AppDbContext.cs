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
        public DbSet<Books> Books { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<RequestHeader> RequestHeader { get; set; }
        public DbSet<RequestDetails> RequestDetails { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<History>().HasOne(c => c.students).WithMany(d => d.histories).HasForeignKey("studentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<History>().HasOne(c => c.admin).WithMany(d => d.history).HasForeignKey("acceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.students).WithMany(d => d.comments).HasForeignKey("studentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BookToBuy>().HasOne(c => c.students).WithMany(c => c.booksTobuy).HasForeignKey("studentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.students).WithMany(d => d.requestHeaders).HasForeignKey("studentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Students>().HasOne(c => c.admins).WithMany(d => d.students).HasForeignKey("adminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.admins).WithMany(c => c.comments).HasForeignKey("acceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.books).WithMany(c => c.comments).HasForeignKey("bookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Users>().HasOne(b => b.students).WithOne(c => c.users).HasForeignKey<Students>(x=> x.userID).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Users>().HasOne(b => b.admins).WithOne(c => c.users).HasForeignKey<Admins>(x=> x.userID).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Books>().HasOne(c => c.admins).WithMany(c => c.books).HasForeignKey("acceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.admins).WithMany(c => c.requestHeader).HasForeignKey("acceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestDetails>().HasOne(c => c.books).WithMany(c => c.requestDetails).HasForeignKey("bookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestDetails>().HasOne(c => c.requestHeader).WithMany(c => c.requestDetails).HasForeignKey("requestHeaderID").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
