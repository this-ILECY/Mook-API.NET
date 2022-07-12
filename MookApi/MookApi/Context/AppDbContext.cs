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
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<BookPublishers> BookPublishers { get; set; }  
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

            builder.Entity<Authors>().HasOne(b => b.AdminsFk).WithMany(d => d.AuthorsFk).HasForeignKey("AdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<History>().HasOne(c => c.students).WithMany(d => d.Historys).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<History>().HasOne(c => c.adminFk).WithMany(d => d.HistoryFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Students).WithMany(d => d.Comments).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.students).WithMany(d => d.RequestHeaders).HasForeignKey("StudentID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Students>().HasOne(c => c.Admins).WithMany(d => d.StudentsFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Admins).WithMany(c => c.CommentsFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comments>().HasOne(c => c.Books).WithMany(c => c.Comments).HasForeignKey("BookID").OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Students>().HasOne(b => b.users).WithOne(c => c.students).HasForeignKey<Students>(c => c.UserID).OnDelete(DeleteBehavior.Restrict);            
            builder.Entity<Students>().HasOne(b => b.users).WithOne(c => c.students).HasForeignKey("Students").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Admins>().HasOne(b => b.UsersFk).WithOne(c => c.Admins).HasForeignKey("Admins").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Publishers>().HasOne(c => c.Admins).WithMany(c => c.PublishersFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Books>().HasOne(c => c.Admins).WithMany(c => c.BooksFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestHeader>().HasOne(c => c.Admins).WithMany(c => c.RequestHeaderFk).HasForeignKey("AcceptedAdminID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BookAuthors>().HasOne(c => c.authors).WithMany(c => c.BookAuthors).HasForeignKey("AuthorID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BookAuthors>().HasOne(c => c.books).WithMany(c => c.bookAuthors).HasForeignKey("BookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<BookPublishers>().HasOne(c => c.publishers).WithMany().HasForeignKey("PublisherID").OnDelete(DeleteBehavior.NoAction);
            builder.Entity<BookPublishers>().HasOne(c => c.books).WithMany(c => c.BookPublishers).HasForeignKey("BookID").OnDelete(DeleteBehavior.NoAction);
            builder.Entity<RequestDetails>().HasOne(c=>c.Books).WithMany(c=> c.RequestDetails).HasForeignKey("BookID").OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RequestDetails>().HasOne(c=>c.RequestHeader).WithMany(c=> c.RequestDetails).HasForeignKey("RequestHeaderID").OnDelete(DeleteBehavior.Restrict);
        }

    }
}
