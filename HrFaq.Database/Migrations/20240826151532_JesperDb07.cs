using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "CreateDatetime", "HitCount", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("00eae4de-014c-4ace-adcf-e38bcb8f6efc"), "Hello world", new DateTime(2024, 8, 26, 17, 15, 32, 522, DateTimeKind.Local).AddTicks(6026), 1, "Jesper" },
                    { new Guid("4bfc4eb2-c496-4e8f-8c24-1986858f1689"), "Hello world", new DateTime(2024, 8, 26, 17, 15, 32, 522, DateTimeKind.Local).AddTicks(6029), 1, "Test" },
                    { new Guid("aabdf4ea-ea4c-40a0-a47e-e2880ffb0f13"), "Hello world", new DateTime(2024, 8, 26, 17, 15, 32, 522, DateTimeKind.Local).AddTicks(5981), 1, "Hej" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("00eae4de-014c-4ace-adcf-e38bcb8f6efc"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("4bfc4eb2-c496-4e8f-8c24-1986858f1689"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("aabdf4ea-ea4c-40a0-a47e-e2880ffb0f13"));

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
    }
}
