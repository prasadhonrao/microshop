using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Customer.MicroService.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Smith" },
                    { 2, "Mary", "Smith" },
                    { 3, "Peter", "Smith" },
                    { 4, "David", "Smith" },
                    { 5, "Paul", "Smith" },
                    { 6, "James", "Smith" },
                    { 7, "Mark", "Smith" },
                    { 8, "Andrew", "Smith" },
                    { 9, "Edward", "Smith" },
                    { 10, "Luke", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderAmount", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, 100.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9690) },
                    { 2, 1, 200.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9749) },
                    { 3, 2, 300.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9752) },
                    { 4, 2, 400.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9754) },
                    { 5, 3, 500.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9755) },
                    { 6, 3, 600.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9757) },
                    { 7, 4, 700.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9759) },
                    { 8, 5, 800.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9760) },
                    { 9, 5, 900.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9762) },
                    { 10, 9, 1000.00m, new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9764) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
