using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SettingInfo",
                columns: table => new
                {
                    SettingInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginUser = table.Column<bool>(type: "bit", nullable: false),
                    RemoveMatchWords = table.Column<bool>(type: "bit", nullable: false),
                    CompanyCategory = table.Column<bool>(type: "bit", nullable: false),
                    AnswerMuli = table.Column<bool>(type: "bit", nullable: false),
                    StatusRapport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingInfo", x => x.SettingInfoId);
                });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "CreateDatetime", "HitCount", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("01688527-b71c-4634-b89c-6fdef5730cf2"), "Hello world", new DateTime(2024, 8, 26, 17, 18, 19, 175, DateTimeKind.Local).AddTicks(4534), 1, "Hej" },
                    { new Guid("26c6603b-eaa9-4438-8990-9ba5a5bb0982"), "Hello world", new DateTime(2024, 8, 26, 17, 18, 19, 175, DateTimeKind.Local).AddTicks(4575), 1, "Jesper" },
                    { new Guid("d6b32b22-1886-4a4e-a77c-4f3f59b06860"), "Hello world", new DateTime(2024, 8, 26, 17, 18, 19, 175, DateTimeKind.Local).AddTicks(4579), 1, "Test" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingInfo");

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("01688527-b71c-4634-b89c-6fdef5730cf2"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("26c6603b-eaa9-4438-8990-9ba5a5bb0982"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("d6b32b22-1886-4a4e-a77c-4f3f59b06860"));

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
    }
}
