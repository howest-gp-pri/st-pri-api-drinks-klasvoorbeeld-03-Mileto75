using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Drinks.Web.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6885), null, "Beer", null },
                    { 2, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6888), null, "Spirits", null }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Created", "Deleted", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6889), null, "Sweet", null },
                    { 2, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6890), null, "bitter", null }
                });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "AlcoholPercentage", "CategoryId", "Created", "Deleted", "Name", "Updated" },
                values: new object[] { 1, 8, 1, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6891), null, "Duvel", null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "AlcoholPercentage", "CategoryId", "Created", "Deleted", "Name", "Updated" },
                values: new object[] { 2, 38, 2, new DateTime(2023, 9, 18, 13, 47, 22, 812, DateTimeKind.Utc).AddTicks(6892), null, "Tequila", null });

            migrationBuilder.InsertData(
                table: "DrinkProperty",
                columns: new[] { "DrinksId", "PropertiesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DrinkProperty",
                keyColumns: new[] { "DrinksId", "PropertiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DrinkProperty",
                keyColumns: new[] { "DrinksId", "PropertiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DrinkProperty",
                keyColumns: new[] { "DrinksId", "PropertiesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DrinkProperty",
                keyColumns: new[] { "DrinksId", "PropertiesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
