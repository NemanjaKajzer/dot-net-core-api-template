using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Doors", "EngineVolume", "Kilometers", "Model", "Power", "ProductionYear", "Seats", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("391ccb12-9a6a-446b-be49-7c99cf73252f"), "BMW", 5, 1999, 100000, "520", 150, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { new Guid("e11512b9-fb83-489b-97d0-021be88f0858"), "Audi", 5, 1800, 90000, "Q3", 170, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("014a8cf3-cb5c-44e3-be4e-4ed6931310b8"), "New customer", 1, 100 },
                    { new Guid("6574ae8c-9e6b-4f35-8609-66ebac9af0c0"), "Returning customer", 2, 5 },
                    { new Guid("df705470-835b-4cb1-b28a-90e0cce7dc81"), "Black Friday", 3, 10 },
                    { new Guid("9b3bc5e0-3f39-49bf-b41b-7435320a78d2"), "No Discount", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("796fb30c-e1a3-4698-be52-f23b615823c5"), "john.smith@js.com", "John", "Smith" });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "CarId", "Currency", "Description", "Price" },
                values: new object[] { new Guid("e11fe273-9f25-4068-9ff5-78dcb1e23c67"), new Guid("391ccb12-9a6a-446b-be49-7c99cf73252f"), 1, "Lorem ipsum", 20000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("e11fe273-9f25-4068-9ff5-78dcb1e23c67"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e11512b9-fb83-489b-97d0-021be88f0858"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("014a8cf3-cb5c-44e3-be4e-4ed6931310b8"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("6574ae8c-9e6b-4f35-8609-66ebac9af0c0"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("9b3bc5e0-3f39-49bf-b41b-7435320a78d2"));

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: new Guid("df705470-835b-4cb1-b28a-90e0cce7dc81"));

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: new Guid("796fb30c-e1a3-4698-be52-f23b615823c5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("391ccb12-9a6a-446b-be49-7c99cf73252f"));

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
        }
    }
}
