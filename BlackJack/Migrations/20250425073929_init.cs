using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackJack.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerScore = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    DealerScore = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Bet = table.Column<decimal>(type: "money", nullable: false),
                    Payout = table.Column<decimal>(type: "money", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GameHisto__userI__49C3F6B7",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameHistory_userId",
                table: "GameHistory",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105342FCF74C4",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__C9F2845696E68EB2",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameHistory");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
