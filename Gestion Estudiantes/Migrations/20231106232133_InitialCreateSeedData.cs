using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Estudiantes.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "Name" },
                values: new object[] { new Guid("22f973e1-f297-4884-b522-2540b44750f5"), "sexto" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "CourseId", "Name" },
                values: new object[] { new Guid("22f973e1-f297-4884-b522-2540b44750f4"), 10, new Guid("22f973e1-f297-4884-b522-2540b44750f5"), "William lasso" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("22f973e1-f297-4884-b522-2540b44750f4"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseId",
                keyValue: new Guid("22f973e1-f297-4884-b522-2540b44750f5"));
        }
    }
}
