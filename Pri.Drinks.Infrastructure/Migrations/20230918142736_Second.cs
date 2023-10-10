using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Drinks.Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 27, 35, 855, DateTimeKind.Utc).AddTicks(3063));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 9, 18, 14, 25, 18, 582, DateTimeKind.Utc).AddTicks(2078));
        }
    }
}
