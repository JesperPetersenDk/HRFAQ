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
    [Migration("20240818114600_JesperDb03")]
    partial class JesperDb03
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

                    b.Property<int?>("HitCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("SearchWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaqId");

                    b.ToTable("Faq");

                    b.HasData(
                        new
                        {
                            FaqId = new Guid("2704f6b3-acf3-4905-9410-9a18aac09c63"),
                            Answer = "Hello world",
                            HitCount = 1,
                            LastUpdate = new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5295),
                            Priority = 1,
                            SearchWords = "Hej"
                        },
                        new
                        {
                            FaqId = new Guid("bd0d38d4-ca3e-4a40-8c14-2a2b49555ffa"),
                            Answer = "Hello world",
                            HitCount = 1,
                            LastUpdate = new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5352),
                            Priority = 1,
                            SearchWords = "Jesper"
                        },
                        new
                        {
                            FaqId = new Guid("298eadaf-0404-4bda-9cb1-f1786fae93fe"),
                            Answer = "Hello world",
                            HitCount = 1,
                            LastUpdate = new DateTime(2024, 8, 18, 13, 45, 59, 956, DateTimeKind.Local).AddTicks(5355),
                            Priority = 1,
                            SearchWords = "Test"
                        });
                });

            modelBuilder.Entity("BlazorHrFaq.Database.Model.MatchData", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchId");

                    b.ToTable("Match");
                });
#pragma warning restore 612, 618
        }
    }
}
