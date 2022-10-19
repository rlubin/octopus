using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class InitAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ApiCalls",
                columns: table => new
                {
                    ApiCallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalledOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCalls", x => x.ApiCallId);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "UserId", "Active", "CreatedOn", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2022, 10, 19, 17, 30, 25, 589, DateTimeKind.Local).AddTicks(2467), "admin@email.com", "admin", "admin" },
                    { 2, true, new DateTime(2022, 10, 19, 17, 30, 25, 589, DateTimeKind.Local).AddTicks(2503), "user1@email.com", "user1", "user1" },
                    { 3, false, new DateTime(2022, 10, 19, 17, 30, 25, 589, DateTimeKind.Local).AddTicks(2505), "user1@email.com", "user2", "user2" }
                });

            migrationBuilder.InsertData(
                table: "ApiKeys",
                columns: new[] { "Key", "CreatedOn", "UserId" },
                values: new object[,]
                {
                    { "1", new DateTime(2022, 10, 19, 17, 30, 25, 589, DateTimeKind.Local).AddTicks(2604), 1 },
                    { "mCQ6qIqkNy", new DateTime(2022, 10, 19, 17, 30, 25, 589, DateTimeKind.Local).AddTicks(2607), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ApiCalls");

            migrationBuilder.DropTable(
                name: "ApiKeys");
        }
    }
}
