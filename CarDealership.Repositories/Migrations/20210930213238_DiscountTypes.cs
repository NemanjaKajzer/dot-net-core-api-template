using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class DiscountTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Discount",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Doors", "EngineVolume", "Kilometers", "Model", "Power", "ProductionYear", "Seats", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("43106731-d03e-4ac1-b627-8eed3cfcafd0"), "BMW", 5, 1999, 100000, "520", 150, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { new Guid("c1242fd8-4248-48e7-8133-48fe962f8ab6"), "Audi", 5, 1800, 90000, "Q3", 170, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("74b6418d-d93d-43fa-80ce-3710563c2d0c"), "New customer", 1, 100 },
                    { new Guid("549f1db8-57da-4d23-b09a-77c8e763983c"), "Returning customer", 2, 5 },
                    { new Guid("c369cec5-d80d-4aec-91eb-df721e061277"), "Black Friday", 3, 10 },
                    { new Guid("4e2b66c7-306d-4ea2-b746-390159102d0f"), "No Discount", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("314ea0c1-522e-413a-9e3a-6213afda2953"), "john.smith@js.com", "John", "Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("43106731-d03e-4ac1-b627-8eed3cfcafd0"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c1242fd8-4248-48e7-8133-48fe962f8ab6"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("4e2b66c7-306d-4ea2-b746-390159102d0f"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("549f1db8-57da-4d23-b09a-77c8e763983c"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("74b6418d-d93d-43fa-80ce-3710563c2d0c"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("c369cec5-d80d-4aec-91eb-df721e061277"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("314ea0c1-522e-413a-9e3a-6213afda2953"));

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Discount");

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
    }
}
