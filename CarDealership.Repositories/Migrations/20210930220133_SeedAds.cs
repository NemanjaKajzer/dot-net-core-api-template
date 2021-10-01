using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class SeedAds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Cars_CarId",
                table: "Ad");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Ad",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Doors", "EngineVolume", "Kilometers", "Model", "Power", "ProductionYear", "Seats", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("a312f304-cb73-4237-8773-0c367941e2c6"), "BMW", 5, 1999, 100000, "520", 150, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { new Guid("90d80355-6ad9-454b-aab5-75d760089adc"), "Audi", 5, 1800, 90000, "Q3", 170, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("14f4ecff-6305-4a86-b123-3de5c8507ce5"), "New customer", 1, 100 },
                    { new Guid("05d5776c-3f21-473b-a27b-230b3ecb4b7b"), "Returning customer", 2, 5 },
                    { new Guid("726bf8e3-35aa-49ca-8db0-f775c5a7597c"), "Black Friday", 3, 10 },
                    { new Guid("bf6b3555-5ec8-4b9d-a071-52fbc55c7d32"), "No Discount", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("c601ae41-3865-4ba3-aa5a-1b8ae16d9278"), "john.smith@js.com", "John", "Smith" });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "CarId", "Currency", "Description", "Price" },
                values: new object[] { new Guid("37513c6c-582a-4680-8932-dc13414d7cdc"), new Guid("a312f304-cb73-4237-8773-0c367941e2c6"), 1, "Lorem ipsum", 20000 });

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Cars_CarId",
                table: "Ad",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_Cars_CarId",
                table: "Ad");

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("37513c6c-582a-4680-8932-dc13414d7cdc"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("90d80355-6ad9-454b-aab5-75d760089adc"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("05d5776c-3f21-473b-a27b-230b3ecb4b7b"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("14f4ecff-6305-4a86-b123-3de5c8507ce5"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("726bf8e3-35aa-49ca-8db0-f775c5a7597c"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("bf6b3555-5ec8-4b9d-a071-52fbc55c7d32"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("c601ae41-3865-4ba3-aa5a-1b8ae16d9278"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a312f304-cb73-4237-8773-0c367941e2c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Ad",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_Cars_CarId",
                table: "Ad",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
