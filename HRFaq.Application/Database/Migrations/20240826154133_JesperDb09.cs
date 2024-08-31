using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("682c5291-1175-49cb-81fd-eadc1b2204c1"), "Hello world", new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3275), 1, "Test" },
                    { new Guid("759f77ea-afca-4df4-8a2a-bbcb9d5f643d"), "Hello world", new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3272), 1, "Jesper" },
                    { new Guid("cfa82d8c-1420-4cd1-9a0b-c3f37b5681f5"), "Hello world", new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3233), 1, "Hej" }
                });

            migrationBuilder.InsertData(
                table: "SettingInfo",
                columns: new[] { "SettingInfoId", "AnswerMuli", "CompanyCategory", "LoginUser", "RemoveMatchWords", "StatusRapport" },
                values: new object[] { new Guid("1427d7a2-dd7b-41dc-a030-e0a9b78e5977"), true, false, false, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("682c5291-1175-49cb-81fd-eadc1b2204c1"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("759f77ea-afca-4df4-8a2a-bbcb9d5f643d"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("cfa82d8c-1420-4cd1-9a0b-c3f37b5681f5"));

            migrationBuilder.DeleteData(
                table: "SettingInfo",
                keyColumn: "SettingInfoId",
                keyValue: new Guid("1427d7a2-dd7b-41dc-a030-e0a9b78e5977"));

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
    }
}
