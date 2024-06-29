using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Class09_EF.Migrations
{
    public partial class populating_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "NumberOfClasses" },
                values: new object[,]
                {
                    { 1, "C# basic", 40 },
                    { 2, "C# advanced", 60 },
                    { 3, "Database development and design", 28 },
                    { 4, "ASP.NET MVC", 40 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ActiveCourseId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(1999, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(4978), "Bob", "Bobski" },
                    { 2, 3, new DateTime(2001, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5021), "John", "Doe" },
                    { 3, 2, new DateTime(2006, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5027), "Todor", "Pelivanov" },
                    { 4, 1, new DateTime(2000, 6, 27, 19, 58, 17, 157, DateTimeKind.Local).AddTicks(5030), "Ivan", "Popovski" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
