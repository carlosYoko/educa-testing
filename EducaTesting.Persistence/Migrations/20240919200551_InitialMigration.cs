using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducaTesting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "DateCreation", "DatePublication", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("279ac295-90cf-4e7b-92fa-a10461966c1e"), new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9025), new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9071), "Curso C#", 59m, "C#" },
                    { new Guid("334cc03b-d2ca-4870-801d-d2abf72accb5"), new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9118), new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9119), "Curso Unit Test .NET", 159m, "Testing .NET" },
                    { new Guid("faf4bc14-8056-4f8b-a68c-03459afbdad3"), new DateTime(2024, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9106), new DateTime(2026, 9, 19, 22, 5, 51, 598, DateTimeKind.Local).AddTicks(9108), "Curso TypeScript", 19m, "TS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
