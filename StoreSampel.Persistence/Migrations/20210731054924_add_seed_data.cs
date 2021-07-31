using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreSampel.Persistence.Migrations
{
    public partial class add_seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[] { 1L, new DateTime(2021, 7, 31, 10, 19, 24, 77, DateTimeKind.Local).AddTicks(6285), "خانواده پژو" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[] { 2L, new DateTime(2021, 7, 31, 10, 19, 24, 79, DateTimeKind.Local).AddTicks(2829), "خانواده رنو" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[] { 3L, new DateTime(2021, 7, 31, 10, 19, 24, 79, DateTimeKind.Local).AddTicks(2991), "خانواده پراید" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 4, 1L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1856), "405GLX" },
                    { 5, 1L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1868), "405slx" },
                    { 6, 2L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1888), "مگان" },
                    { 7, 2L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1899), "سانرو" },
                    { 8, 2L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1911), "کولیوس" },
                    { 1, 3L, new DateTime(2021, 7, 31, 10, 19, 24, 86, DateTimeKind.Local).AddTicks(9505), "111" },
                    { 2, 3L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1767), "131" },
                    { 3, 3L, new DateTime(2021, 7, 31, 10, 19, 24, 87, DateTimeKind.Local).AddTicks(1842), "141" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CreateDate", "ModelId", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6000), 4, "بنزینی" },
                    { 3, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6062), 4, "دوگانه سوز" },
                    { 1, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(4659), 5, "بنزینی" },
                    { 6, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6154), 6, "بنزینی 1700cc" },
                    { 7, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6168), 6, "بنزینی 2000cc" },
                    { 8, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6180), 7, "بنزینی 1800cc" },
                    { 9, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6192), 7, "بنزینی cross over" },
                    { 10, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6207), 8, "بنزینی " },
                    { 4, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6075), 1, "بنزینی" },
                    { 5, new DateTime(2021, 7, 31, 10, 19, 24, 89, DateTimeKind.Local).AddTicks(6087), 1, "بنزینی slx" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
