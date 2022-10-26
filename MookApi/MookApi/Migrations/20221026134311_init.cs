using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MookApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminID);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPagesCount = table.Column<int>(type: "int", nullable: false),
                    bookRating = table.Column<float>(type: "real", nullable: false),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookRatingCount = table.Column<int>(type: "int", nullable: false),
                    bookDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    isDamaged = table.Column<bool>(type: "bit", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookID);
                    table.ForeignKey(
                        name: "FK_Books_Admins_acceptedAdminID",
                        column: x => x.acceptedAdminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<long>(type: "bigint", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentSSID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentUniversityID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spamCount = table.Column<int>(type: "int", nullable: false),
                    isSuspended = table.Column<bool>(type: "bit", nullable: false),
                    isRegistered = table.Column<bool>(type: "bit", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    reportPoint = table.Column<int>(type: "int", nullable: false),
                    isSpam = table.Column<bool>(type: "bit", nullable: false),
                    adminID = table.Column<int>(type: "int", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_Students_Admins_adminID",
                        column: x => x.adminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_userID",
                        column: x => x.userID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookToBuy",
                columns: table => new
                {
                    bookToBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPublisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookToBuy", x => x.bookToBuyId);
                    table.ForeignKey(
                        name: "FK_BookToBuy_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fatherID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    commentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commentLike = table.Column<float>(type: "real", nullable: false),
                    commentDislike = table.Column<float>(type: "real", nullable: false),
                    commentFlag = table.Column<bool>(type: "bit", nullable: false),
                    isAdminAccepted = table.Column<bool>(type: "bit", nullable: false),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comments_Admins_acceptedAdminID",
                        column: x => x.acceptedAdminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Books_bookID",
                        column: x => x.bookID,
                        principalTable: "Books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    historyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    columnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    columnChanged = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<int>(type: "int", nullable: false),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.historyID);
                    table.ForeignKey(
                        name: "FK_History_Admins_acceptedAdminID",
                        column: x => x.acceptedAdminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_History_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestHeader",
                columns: table => new
                {
                    requestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    requestAcceptedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false),
                    requestFinishedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestDecription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHeader", x => x.requestID);
                    table.ForeignKey(
                        name: "FK_RequestHeader_Admins_acceptedAdminID",
                        column: x => x.acceptedAdminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestHeader_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetails",
                columns: table => new
                {
                    requestDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestHeaderID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    requestDetailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDamaged = table.Column<bool>(type: "bit", nullable: true),
                    isLost = table.Column<bool>(type: "bit", nullable: true),
                    acceptedAdminID = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    updateDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetails", x => x.requestDetailID);
                    table.ForeignKey(
                        name: "FK_RequestDetails_Books_bookID",
                        column: x => x.bookID,
                        principalTable: "Books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestDetails_RequestHeader_requestHeaderID",
                        column: x => x.requestHeaderID,
                        principalTable: "RequestHeader",
                        principalColumn: "requestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_userID",
                table: "Admins",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_acceptedAdminID",
                table: "Books",
                column: "acceptedAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_BookToBuy_studentID",
                table: "BookToBuy",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_acceptedAdminID",
                table: "Comments",
                column: "acceptedAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_bookID",
                table: "Comments",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_studentID",
                table: "Comments",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_History_acceptedAdminID",
                table: "History",
                column: "acceptedAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_History_studentID",
                table: "History",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_bookID",
                table: "RequestDetails",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_requestHeaderID",
                table: "RequestDetails",
                column: "requestHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeader_acceptedAdminID",
                table: "RequestHeader",
                column: "acceptedAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHeader_studentID",
                table: "RequestHeader",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_adminID",
                table: "Students",
                column: "adminID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_userID",
                table: "Students",
                column: "userID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookToBuy");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "RequestDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "RequestHeader");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
