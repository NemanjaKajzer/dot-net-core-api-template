using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class SeedCarsSellers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("69073837-cb08-4ff1-b238-63b620f7b27b"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("796a00c5-84e4-4b21-90c9-6ab1b3ac509f"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("a8410f7e-4e8e-4628-8cce-97a286aac6a7"));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Doors", "EngineVolume", "Kilometers", "Model", "Power", "ProductionYear", "Seats", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("7b7e48ef-c542-4d30-8de6-73624c0d76df"), "BMW", 5, 1999, 100000, "520", 150, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { new Guid("233fa880-bd3b-440c-b0da-f9afb7fe6292"), "Audi", 5, 1800, 90000, "Q3", 170, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Value" },
                values: new object[,]
                {
                    { new Guid("fcf32728-8e0e-429b-9c18-7e707c52f7a3"), "New customer", 100 },
                    { new Guid("5dbbb375-f3fd-430f-8d9f-bfa46a64d852"), "Returning customer", 5 },
                    { new Guid("47bd7d45-b684-4bc3-b98a-08b436407f81"), "Black Friday", 10 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("51c59ac5-80ed-4a9d-af62-78a4d4aca32c"), "john.smith@js.com", "John", "Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("233fa880-bd3b-440c-b0da-f9afb7fe6292"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7b7e48ef-c542-4d30-8de6-73624c0d76df"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("47bd7d45-b684-4bc3-b98a-08b436407f81"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("5dbbb375-f3fd-430f-8d9f-bfa46a64d852"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("fcf32728-8e0e-429b-9c18-7e707c52f7a3"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("51c59ac5-80ed-4a9d-af62-78a4d4aca32c"));

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Value" },
                values: new object[,]
                {
                    { new Guid("a8410f7e-4e8e-4628-8cce-97a286aac6a7"), "New customer", 100 },
                    { new Guid("69073837-cb08-4ff1-b238-63b620f7b27b"), "Returning customer", 5 },
                    { new Guid("796a00c5-84e4-4b21-90c9-6ab1b3ac509f"), "Black Friday", 10 }
                });
        }
    }
}
