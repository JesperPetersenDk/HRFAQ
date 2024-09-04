using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrFaq.Application.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("4c512596-f445-4288-98d6-6dfc5cac2e91"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("d1e47480-3065-45a2-b77c-d8fdce743211"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("f7b32e68-9fad-423a-b00d-e6fa9fab2db0"));

            migrationBuilder.DeleteData(
                table: "SettingInfo",
                keyColumn: "SettingInfoId",
                keyValue: new Guid("cfd4f342-7b49-4d16-b4ab-220d2cb1b70f"));

            migrationBuilder.DropColumn(
                name: "LinkTarget",
                table: "SettingInfo");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateAsked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionStats",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionStats", x => new { x.Date, x.QuestionType });
                });

            migrationBuilder.InsertData(
                table: "Faq",
                columns: new[] { "FaqId", "Answer", "CreateDatetime", "HitCount", "SearchWords" },
                values: new object[,]
                {
                    { new Guid("07c15be6-960b-4c13-8819-e8732ce13eee"), "Hello world", new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(991), 1, "Hej" },
                    { new Guid("99e73cd0-b183-4c4f-be7b-e3b4cb540cd5"), "Hello world", new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(1055), 1, "Test" },
                    { new Guid("9dcee081-3c86-480f-8ce2-93a6f3904c95"), "Hello world", new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(1038), 1, "Jesper" }
                });

            migrationBuilder.InsertData(
                table: "SettingInfo",
                columns: new[] { "SettingInfoId", "AnswerMuli", "CompanyCategory", "LoginUser", "RemoveMatchWords", "StatusRapport" },
                values: new object[] { new Guid("90506d3a-4e1f-440f-87e0-ed9157e25fe5"), true, false, false, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionStats");

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("07c15be6-960b-4c13-8819-e8732ce13eee"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("99e73cd0-b183-4c4f-be7b-e3b4cb540cd5"));

            migrationBuilder.DeleteData(
                table: "Faq",
                keyColumn: "FaqId",
                keyValue: new Guid("9dcee081-3c86-480f-8ce2-93a6f3904c95"));

            migrationBuilder.DeleteData(
                table: "SettingInfo",
                keyColumn: "SettingInfoId",
                keyValue: new Guid("90506d3a-4e1f-440f-87e0-ed9157e25fe5"));

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
                    { new Guid("4c512596-f445-4288-98d6-6dfc5cac2e91"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3303), 1, "Hej" },
                    { new Guid("d1e47480-3065-45a2-b77c-d8fdce743211"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3352), 1, "Test" },
                    { new Guid("f7b32e68-9fad-423a-b00d-e6fa9fab2db0"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3349), 1, "Jesper" }
                });

            migrationBuilder.InsertData(
                table: "SettingInfo",
                columns: new[] { "SettingInfoId", "AnswerMuli", "CompanyCategory", "LinkTarget", "LoginUser", "RemoveMatchWords", "StatusRapport" },
                values: new object[] { new Guid("cfd4f342-7b49-4d16-b4ab-220d2cb1b70f"), true, false, true, false, false, true });
        }
    }
}
