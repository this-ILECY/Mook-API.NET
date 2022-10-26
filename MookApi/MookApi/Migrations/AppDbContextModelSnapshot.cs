﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MookApi.Context;

#nullable disable

namespace MookApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MookApi.Models.Admins", b =>
                {
                    b.Property<int>("adminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<string>("adminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("adminID");

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MookApi.Models.Books", b =>
                {
                    b.Property<int>("bookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("bookPagesCount")
                        .HasColumnType("int");

                    b.Property<float>("bookRating")
                        .HasColumnType("real");

                    b.Property<int>("bookRatingCount")
                        .HasColumnType("int");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("isDamaged")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("bookID");

                    b.HasIndex("acceptedAdminID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MookApi.Models.BookToBuy", b =>
                {
                    b.Property<int>("bookToBuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookToBuyId"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<string>("bookAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookPublisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("bookToBuyId");

                    b.HasIndex("studentID");

                    b.ToTable("BookToBuy");
                });

            modelBuilder.Entity("MookApi.Models.Comments", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<string>("commentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("commentDislike")
                        .HasColumnType("real");

                    b.Property<bool>("commentFlag")
                        .HasColumnType("bit");

                    b.Property<string>("commentHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("commentLike")
                        .HasColumnType("real");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("fatherID")
                        .HasColumnType("int");

                    b.Property<bool>("isAdminAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("commentID");

                    b.HasIndex("acceptedAdminID");

                    b.HasIndex("bookID");

                    b.HasIndex("studentID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MookApi.Models.History", b =>
                {
                    b.Property<int>("historyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("historyID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<string>("columnChanged")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("columnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.Property<int>("tableID")
                        .HasColumnType("int");

                    b.Property<string>("tableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("historyID");

                    b.HasIndex("acceptedAdminID");

                    b.HasIndex("studentID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("MookApi.Models.RequestDetails", b =>
                {
                    b.Property<int>("requestDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("requestDetailID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool?>("isDamaged")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("isLost")
                        .HasColumnType("bit");

                    b.Property<string>("requestDetailDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("requestHeaderID")
                        .HasColumnType("int");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("requestDetailID");

                    b.HasIndex("bookID");

                    b.HasIndex("requestHeaderID");

                    b.ToTable("RequestDetails");
                });

            modelBuilder.Entity("MookApi.Models.RequestHeader", b =>
                {
                    b.Property<int>("requestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("requestID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("requestAcceptedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requestDecription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requestFinishedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("requestID");

                    b.HasIndex("acceptedAdminID");

                    b.HasIndex("studentID");

                    b.ToTable("RequestHeader");
                });

            modelBuilder.Entity("MookApi.Models.Roles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("MookApi.Models.Students", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentID"), 1L, 1);

                    b.Property<int?>("acceptedAdminID")
                        .HasColumnType("int");

                    b.Property<int>("adminID")
                        .HasColumnType("int");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isRegistered")
                        .HasColumnType("bit");

                    b.Property<bool>("isSpam")
                        .HasColumnType("bit");

                    b.Property<bool>("isSuspended")
                        .HasColumnType("bit");

                    b.Property<int>("reportPoint")
                        .HasColumnType("int");

                    b.Property<int>("spamCount")
                        .HasColumnType("int");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentSSID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentUniversityID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updateDate")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("studentID");

                    b.HasIndex("adminID");

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MookApi.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("createdDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("MookApi.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("MookApi.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("MookApi.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("MookApi.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MookApi.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("MookApi.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MookApi.Models.Admins", b =>
                {
                    b.HasOne("MookApi.Models.Users", "users")
                        .WithOne("admins")
                        .HasForeignKey("MookApi.Models.Admins", "userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("users");
                });

            modelBuilder.Entity("MookApi.Models.Books", b =>
                {
                    b.HasOne("MookApi.Models.Admins", "admins")
                        .WithMany("books")
                        .HasForeignKey("acceptedAdminID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("admins");
                });

            modelBuilder.Entity("MookApi.Models.BookToBuy", b =>
                {
                    b.HasOne("MookApi.Models.Students", "students")
                        .WithMany("booksTobuy")
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("students");
                });

            modelBuilder.Entity("MookApi.Models.Comments", b =>
                {
                    b.HasOne("MookApi.Models.Admins", "admins")
                        .WithMany("comments")
                        .HasForeignKey("acceptedAdminID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MookApi.Models.Books", "books")
                        .WithMany("comments")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MookApi.Models.Students", "students")
                        .WithMany("comments")
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("admins");

                    b.Navigation("books");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MookApi.Models.History", b =>
                {
                    b.HasOne("MookApi.Models.Admins", "admin")
                        .WithMany("history")
                        .HasForeignKey("acceptedAdminID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MookApi.Models.Students", "students")
                        .WithMany("histories")
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("admin");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MookApi.Models.RequestDetails", b =>
                {
                    b.HasOne("MookApi.Models.Books", "books")
                        .WithMany("requestDetails")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MookApi.Models.RequestHeader", "requestHeader")
                        .WithMany("requestDetails")
                        .HasForeignKey("requestHeaderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("books");

                    b.Navigation("requestHeader");
                });

            modelBuilder.Entity("MookApi.Models.RequestHeader", b =>
                {
                    b.HasOne("MookApi.Models.Admins", "admins")
                        .WithMany("requestHeader")
                        .HasForeignKey("acceptedAdminID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MookApi.Models.Students", "students")
                        .WithMany("requestHeaders")
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("admins");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MookApi.Models.Students", b =>
                {
                    b.HasOne("MookApi.Models.Admins", "admins")
                        .WithMany("students")
                        .HasForeignKey("adminID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MookApi.Models.Users", "users")
                        .WithOne("students")
                        .HasForeignKey("MookApi.Models.Students", "userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("admins");

                    b.Navigation("users");
                });

            modelBuilder.Entity("MookApi.Models.Admins", b =>
                {
                    b.Navigation("books");

                    b.Navigation("comments");

                    b.Navigation("history");

                    b.Navigation("requestHeader");

                    b.Navigation("students");
                });

            modelBuilder.Entity("MookApi.Models.Books", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("requestDetails");
                });

            modelBuilder.Entity("MookApi.Models.RequestHeader", b =>
                {
                    b.Navigation("requestDetails");
                });

            modelBuilder.Entity("MookApi.Models.Students", b =>
                {
                    b.Navigation("booksTobuy");

                    b.Navigation("comments");

                    b.Navigation("histories");

                    b.Navigation("requestHeaders");
                });

            modelBuilder.Entity("MookApi.Models.Users", b =>
                {
                    b.Navigation("admins")
                        .IsRequired();

                    b.Navigation("students")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
