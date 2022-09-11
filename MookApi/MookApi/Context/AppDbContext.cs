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

            builder.Entity<History>().HasOne(c => c.students).WithMany(d => d.Histories).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<History>().HasOne(c => c.adminFk).WithMany(d => d.HistoryFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Students).WithMany(d => d.Comments).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BookToBuy>().HasOne(c => c.Students).WithMany(c => c.BooksTobuy).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.students).WithMany(d => d.RequestHeaders).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Students>().HasOne(c => c.Admins).WithMany(d => d.StudentsFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Admins).WithMany(c => c.CommentsFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Books).WithMany(c => c.Comments).HasForeignKey("BookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Students>().HasOne(b => b.users).WithOne(c => c.students).HasForeignKey("Students").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Admins>().HasOne(b => b.UsersFk).WithOne(c => c.Admins).HasForeignKey("Admins").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Books>().HasOne(c => c.Admins).WithMany(c => c.BooksFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.Admins).WithMany(c => c.RequestHeaderFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestDetails>().HasOne(c => c.Books).WithMany(c => c.RequestDetails).HasForeignKey("BookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestDetails>().HasOne(c => c.RequestHeader).WithMany(c => c.RequestDetails).HasForeignKey("RequestHeaderID").OnDelete(DeleteBehavior.Restrict);
        }
    }
}
