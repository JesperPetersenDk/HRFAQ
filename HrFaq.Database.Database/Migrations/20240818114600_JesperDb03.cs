using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("0868c46c-1560-4258-b9a1-e4d6a698bc8e"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("8389b381-da41-4ba8-870a-a9b5ed138ef2"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("cd5d5a55-74af-41a4-804f-9c1b8e6bfd49"));

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "HitCount", "LastUpdate", "Priority", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("2704f6b3-acf3-4905-9410-9a18aac09c63"), "Hello world", 1, new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5295), 1, "Hej" },
                    { new Guid("298eadaf-0404-4bda-9cb1-f1786fae93fe"), "Hello world", 1, new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5355), 1, "Test" },
                    { new Guid("bd0d38d4-ca3e-4a40-8c14-2a2b49555ffa"), "Hello world", 1, new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5352), 1, "Jesper" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("2704f6b3-acf3-4905-9410-9a18aac09c63"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("298eadaf-0404-4bda-9cb1-f1786fae93fe"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("bd0d38d4-ca3e-4a40-8c14-2a2b49555ffa"));

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "HitCount", "LastUpdate", "Priority", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("0868c46c-1560-4258-b9a1-e4d6a698bc8e"), "Hello world", 1, new DateTime(2024, 8, 17, 21, 31, 19, 277, DateTimeKind.Local).AddTicks(8190), 1, "Hej" },
                    { new Guid("8389b381-da41-4ba8-870a-a9b5ed138ef2"), "Hello world", 1, new DateTime(2024, 8, 17, 21, 31, 19, 277, DateTimeKind.Local).AddTicks(8239), 1, "Jesper" },
                    { new Guid("cd5d5a55-74af-41a4-804f-9c1b8e6bfd49"), "Hello world", 1, new DateTime(2024, 8, 17, 21, 31, 19, 277, DateTimeKind.Local).AddTicks(8242), 1, "Test" }
                });
        }
    }
}
