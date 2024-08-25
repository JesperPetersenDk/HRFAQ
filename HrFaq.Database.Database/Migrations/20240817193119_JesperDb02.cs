using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
