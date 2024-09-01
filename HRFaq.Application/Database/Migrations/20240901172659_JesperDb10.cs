using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHrFaq.Database.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "LinkTarget",
                table: "SettingInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "CreateDatetime", "HitCount", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("24112ecf-afc7-4ae8-bfe0-850a90b52847"), "Hello world", new DateTime(2024, 9, 1, 19, 26, 58, 787, DateTimeKind.Local).AddTicks(9433), 1, "Hej" },
                    { new Guid("4157d7bd-aacf-4ad7-8a0e-0f9413df9e39"), "Hello world", new DateTime(2024, 9, 1, 19, 26, 58, 787, DateTimeKind.Local).AddTicks(9480), 1, "Jesper" },
                    { new Guid("5a2a38df-5878-46ab-a1fc-279221db1319"), "Hello world", new DateTime(2024, 9, 1, 19, 26, 58, 787, DateTimeKind.Local).AddTicks(9483), 1, "Test" }
                });

            migrationBuilder.InsertData(
                table: "SettingInfo",
                columns: new[] { "SettingInfoId", "AnswerMuli", "CompanyCategory", "LinkTarget", "LoginUser", "RemoveMatchWords", "StatusRapport" },
                values: new object[] { new Guid("d5b95c63-8fcb-4d28-8056-4a03a238f077"), true, false, true, false, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("24112ecf-afc7-4ae8-bfe0-850a90b52847"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("4157d7bd-aacf-4ad7-8a0e-0f9413df9e39"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("5a2a38df-5878-46ab-a1fc-279221db1319"));

            migrationBuilder.DeleteData(
                table: "SettingInfo",
                keyColumn: "SettingInfoId",
                keyValue: new Guid("d5b95c63-8fcb-4d28-8056-4a03a238f077"));

            migrationBuilder.DropColumn(
                name: "LinkTarget",
                table: "SettingInfo");

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
    }
}
