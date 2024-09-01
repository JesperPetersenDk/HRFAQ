using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrFaq.Application.Migrations
{
    /// <inheritdoc />
    public partial class JesperDb001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    FaqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HitCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "SettingInfo",
                columns: table => new
                {
                    SettingInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginUser = table.Column<bool>(type: "bit", nullable: false),
                    RemoveMatchWords = table.Column<bool>(type: "bit", nullable: false),
                    CompanyCategory = table.Column<bool>(type: "bit", nullable: false),
                    AnswerMuli = table.Column<bool>(type: "bit", nullable: false),
                    StatusRapport = table.Column<bool>(type: "bit", nullable: false),
                    LinkTarget = table.Column<bool>(type: "bit", nullable: false)
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
                    { new Guid("4c512596-f445-4288-98d6-6dfc5cac2e91"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3303), 1, "Hej" },
                    { new Guid("d1e47480-3065-45a2-b77c-d8fdce743211"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3352), 1, "Test" },
                    { new Guid("f7b32e68-9fad-423a-b00d-e6fa9fab2db0"), "Hello world", new DateTime(2024, 9, 1, 20, 55, 54, 61, DateTimeKind.Local).AddTicks(3349), 1, "Jesper" }
                });

            migrationBuilder.InsertData(
                table: "SettingInfo",
                columns: new[] { "SettingInfoId", "AnswerMuli", "CompanyCategory", "LinkTarget", "LoginUser", "RemoveMatchWords", "StatusRapport" },
                values: new object[] { new Guid("cfd4f342-7b49-4d16-b4ab-220d2cb1b70f"), true, false, true, false, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "SettingInfo");
        }
    }
}
