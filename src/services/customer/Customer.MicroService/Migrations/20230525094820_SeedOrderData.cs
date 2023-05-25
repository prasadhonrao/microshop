using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.MicroService.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Doe");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "Jane");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Michael", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Emily", "Brown" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Daniel", "Miller" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Olivia", "Davis" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "William", "Garcia" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sophia", "Martinez" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Matthew", "Anderson" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Isabella", "Thomas" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderDate",
                value: new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Smith");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "Mary");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Peter", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "David", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Paul", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mark", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Andrew", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Edward", "Smith" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Luke", "Smith" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                column: "OrderDate",
                value: new DateTime(2023, 5, 25, 10, 34, 29, 794, DateTimeKind.Local).AddTicks(9764));
        }
    }
}
