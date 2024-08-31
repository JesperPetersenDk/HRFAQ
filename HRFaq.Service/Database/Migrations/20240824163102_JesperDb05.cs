using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("4be51388-febd-48a3-be7f-ce7f22daa4f8"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("9dbfad93-3b86-48c7-9cf2-b1740f547088"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("f33b61a9-10c1-4213-a381-f8b1c92098f6"));

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Faq");

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "HitCount", "LastUpdate", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("16684a83-f85f-42c0-be95-26587dc387bb"), "Hello world", 1, new DateTime(2024, 8, 24, 18, 31, 2, 0, DateTimeKind.Local).AddTicks(6443), "Hej" },
                    { new Guid("9c58e705-0288-4a0d-961c-d71b6ff35886"), "Hello world", 1, new DateTime(2024, 8, 24, 18, 31, 2, 0, DateTimeKind.Local).AddTicks(6507), "Jesper" },
                    { new Guid("c586c144-7d0f-4efa-a899-7e111f216079"), "Hello world", 1, new DateTime(2024, 8, 24, 18, 31, 2, 0, DateTimeKind.Local).AddTicks(6510), "Test" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("16684a83-f85f-42c0-be95-26587dc387bb"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("9c58e705-0288-4a0d-961c-d71b6ff35886"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("c586c144-7d0f-4efa-a899-7e111f216079"));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Faq",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "HitCount", "LastUpdate", "Priority", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("4be51388-febd-48a3-be7f-ce7f22daa4f8"), "Hello world", 1, new DateTime(2024, 8, 23, 21, 15, 23, 464, DateTimeKind.Local).AddTicks(5298), 1, "Hej" },
                    { new Guid("9dbfad93-3b86-48c7-9cf2-b1740f547088"), "Hello world", 1, new DateTime(2024, 8, 23, 21, 15, 23, 464, DateTimeKind.Local).AddTicks(5431), 1, "Test" },
                    { new Guid("f33b61a9-10c1-4213-a381-f8b1c92098f6"), "Hello world", 1, new DateTime(2024, 8, 23, 21, 15, 23, 464, DateTimeKind.Local).AddTicks(5428), 1, "Jesper" }
                });
        }
    }
}
