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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCalls", x => x.ApiCallId);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    ApiKeyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.ApiKeyId);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "UserId", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin@email.com", "admin", "admin" },
                    { 2, "user1@email.com", "user1", "user1" }
                });

            migrationBuilder.InsertData(
                table: "ApiKeys",
                columns: new[] { "ApiKeyId", "Active", "Key", "UserId" },
                values: new object[,]
                {
                    { 1, true, "1", 1 },
                    { 2, true, "2", 2 }
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
