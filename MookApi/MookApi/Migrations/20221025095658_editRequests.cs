using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MookApi.Migrations
{
    public partial class editRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayDays",
                table: "RequestHeader");

            migrationBuilder.DropColumn(
                name: "IsDelayed",
                table: "RequestHeader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelayDays",
                table: "RequestHeader",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelayed",
                table: "RequestHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
