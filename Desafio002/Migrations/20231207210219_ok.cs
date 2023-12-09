using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio002.Migrations
{
    public partial class ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "url",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrlEncurtada = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_url_URL",
                table: "url",
                column: "URL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_url_UrlEncurtada",
                table: "url",
                column: "UrlEncurtada",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "url");
        }
    }
}
