﻿// <auto-generated />
using System;
using EducaTesting.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducaTesting.Persistence.Migrations
{
    [DbContext(typeof(EducaTestingDbContext))]
    [Migration("20240919200551_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EducaTesting.Domain.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("279ac295-90cf-4e7b-92fa-a10461966c1e"),
                            DateCreation = new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9025),
                            DatePublication = new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9071),
                            Description = "Curso C#",
                            Price = 59m,
                            Title = "C#"
                        },
                        new
                        {
                            CourseId = new Guid("faf4bc14-8056-4f8b-a68c-03459afbdad3"),
                            DateCreation = new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9106),
                            DatePublication = new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9108),
                            Description = "Curso TypeScript",
                            Price = 19m,
                            Title = "TS"
                        },
                        new
                        {
                            CourseId = new Guid("334cc03b-d2ca-4870-801d-d2abf72accb5"),
                            DateCreation = new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9118),
                            DatePublication = new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9119),
                            Description = "Curso Unit Test .NET",
                            Price = 159m,
                            Title = "Testing .NET"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
