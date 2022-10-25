using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MookApi.Migrations
{
    public partial class editRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Students",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RequestHeader",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RequestDetails",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "History",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Comments",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "BookToBuy",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Books",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Books",
                newName: "bookID");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Admins",
                newName: "createdDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Students",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "RequestHeader",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "RequestDetails",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "History",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Comments",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "BookToBuy",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Books",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "bookID",
                table: "Books",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Admins",
                newName: "CreatedDate");
        }
    }
}
