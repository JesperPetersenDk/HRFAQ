﻿// <auto-generated />
using System;
using BlazorHrFaq.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorHrFaq.Database.Migrations
{
    [DbContext(typeof(DatabaseDb))]
    [Migration("20240826154133_JesperDb09")]
    partial class JesperDb09
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
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
                            FaqId = new Guid("cfa82d8c-1420-4cd1-9a0b-c3f37b5681f5"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3233),
                            HitCount = 1,
                            SearchWords = "Hej"
                        },
                        new
                        {
                            FaqId = new Guid("759f77ea-afca-4df4-8a2a-bbcb9d5f643d"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3272),
                            HitCount = 1,
                            SearchWords = "Jesper"
                        },
                        new
                        {
                            FaqId = new Guid("682c5291-1175-49cb-81fd-eadc1b2204c1"),
                            Answer = "Hello world",
                            CreateDatetime = new DateTime(2024, 8, 26, 17, 41, 33, 91, DateTimeKind.Local).AddTicks(3275),
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
                            SettingInfoId = new Guid("1427d7a2-dd7b-41dc-a030-e0a9b78e5977"),
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
