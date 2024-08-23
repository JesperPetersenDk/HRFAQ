using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Match",
                newName: "CodeValue");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CodeValue",
                table: "Match",
                newName: "Type");

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
    }
}
