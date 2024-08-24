using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Faq");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDatetime",
                table: "Faq",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "CreateDatetime", "HitCount", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("27554c9c-9908-4502-bd86-eab867007cca"), "Hello world", new DateTime(2024, 8, 24, 18, 37, 48, 754, DateTimeKind.Local).AddTicks(3892), 1, "Jesper" },
                    { new Guid("aad30447-2a5c-42b5-9ffb-911ce6992110"), "Hello world", new DateTime(2024, 8, 24, 18, 37, 48, 754, DateTimeKind.Local).AddTicks(3895), 1, "Test" },
                    { new Guid("ab149676-7460-4acb-8709-d0c5da325a1d"), "Hello world", new DateTime(2024, 8, 24, 18, 37, 48, 754, DateTimeKind.Local).AddTicks(3835), 1, "Hej" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("27554c9c-9908-4502-bd86-eab867007cca"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("aad30447-2a5c-42b5-9ffb-911ce6992110"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("ab149676-7460-4acb-8709-d0c5da325a1d"));

            migrationBuilder.DropColumn(
                name: "CreateDatetime",
                table: "Faq");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Faq",
                type: "datetime2",
                nullable: true);

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
    }
}
