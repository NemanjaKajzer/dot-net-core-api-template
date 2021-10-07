using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Repositories.Migrations
{
    public partial class productionyearint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Power = table.Column<int>(type: "integer", nullable: false),
                    Seats = table.Column<int>(type: "integer", nullable: false),
                    Doors = table.Column<int>(type: "integer", nullable: false),
                    EngineVolume = table.Column<int>(type: "integer", nullable: false),
                    Kilometers = table.Column<int>(type: "integer", nullable: false),
                    ProductionYear = table.Column<int>(type: "integer", nullable: false),
                    TransmissionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PromoCode = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarId = table.Column<Guid>(type: "uuid", nullable: true),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ad_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ad_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Doors", "EngineVolume", "Kilometers", "Model", "Power", "ProductionYear", "Seats", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("c5d040f0-aa56-4923-8c03-82689650554d"), "BMW", 5, 1999, 100000, "520", 150, 2000, 5, 2 },
                    { new Guid("2523e318-f9fc-4beb-9347-e1ab0ae14347"), "Audi", 5, 1800, 90000, "Q3", 170, 2010, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "PromoCode", "Type", "Value" },
                values: new object[,]
                {
                    { new Guid("70511618-91ac-451f-8c45-5b52d2da9f86"), "NEW", 1, 100 },
                    { new Guid("e7902086-8de5-4581-816c-d2c301448f10"), "RETURN", 2, 5 },
                    { new Guid("bb6ff972-0c1f-4f12-b089-a12a301f7dea"), "BF2021", 3, 10 },
                    { new Guid("0f68dad7-1809-477e-82b6-145dd7d98904"), "No Discount", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { new Guid("b1846008-e76a-4f59-aa64-cd247896a63e"), "john.smith@js.com", "John", "Smith" });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_CarId",
                table: "Ad",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ad_SellerId",
                table: "Ad",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
