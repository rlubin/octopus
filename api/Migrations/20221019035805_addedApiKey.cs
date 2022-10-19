using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class addedApiKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "UserId",
                keyValue: 1,
                column: "ApiKey",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "UserId",
                keyValue: 2,
                column: "ApiKey",
                value: "2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Accounts");
        }
    }
}
