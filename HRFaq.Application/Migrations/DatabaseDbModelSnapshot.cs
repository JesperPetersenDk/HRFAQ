﻿// <auto-generated />
using System;
using BlazorHrFaq.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HrFaq.Application.Migrations
{
    [DbContext(typeof(DatabaseDb))]
    partial class DatabaseDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorHrFaq.Database.Model.Faq", b =>
                {
                    b.Property<Guid>("FaqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HitCount")
                        .HasColumnType("int");

                    b.Property<string>("SearchWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaqId");

                    b.ToTable("Faq");

                    b.HasData(
                        new
                        {
                            FaqId = new Guid("07c15be6-960b-4c13-8819-e8732ce13eee"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(991),
                            HitCount = 1,
                            SearchWords = "Hej"
                        },
                        new
                        {
                            FaqId = new Guid("9dcee081-3c86-480f-8ce2-93a6f3904c95"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(1038),
                            HitCount = 1,
                            SearchWords = "Jesper"
                        },
                        new
                        {
                            FaqId = new Guid("99e73cd0-b183-4c4f-be7b-e3b4cb540cd5"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 9, 3, 19, 33, 54, 815, DateTimeKind.Local).AddTicks(1055),
                            HitCount = 1,
                            SearchWords = "Test"
                        });
                });

            modelBuilder.Entity("BlazorHrFaq.Database.Model.MatchData", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodeValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("HrFaq.Application.Database.Model.QuestionStats", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(1);

                    b.Property<string>("QuestionType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(2);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Date", "QuestionType");

                    b.ToTable("QuestionStats");
                });

            modelBuilder.Entity("HrFaq.Application.Database.Model.Questions", b =>
                {
                    b.Property<Guid>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAsked")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("QuestionID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("HrFaq.Database.Model.SettingInfo", b =>
                {
                    b.Property<Guid>("SettingInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AnswerMuli")
                        .HasColumnType("bit");

                    b.Property<bool>("CompanyCategory")
                        .HasColumnType("bit");

                    b.Property<bool>("LoginUser")
                        .HasColumnType("bit");

                    b.Property<bool>("RemoveMatchWords")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusRapport")
                        .HasColumnType("bit");

                    b.HasKey("SettingInfoId");

                    b.ToTable("SettingInfo");

                    b.HasData(
                        new
                        {
                            SettingInfoId = new Guid("90506d3a-4e1f-440f-87e0-ed9157e25fe5"),
                            AnswerMuli = true,
                            CompanyCategory = false,
                            LoginUser = false,
                            RemoveMatchWords = false,
                            StatusRapport = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
