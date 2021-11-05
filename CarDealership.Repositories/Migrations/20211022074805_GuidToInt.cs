using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarDealership.Repositories.Migrations
{
    public partial class GuidToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: true),
                    SellerId = table.Column<int>(type: "integer", nullable: true),
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
                    { 1, "BMW", 5, 1999, 100000, "520", 150, 2000, 5, 2 },
                    { 2, "Audi", 5, 1800, 90000, "Q3", 170, 2010, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "PromoCode", "Type", "Value" },
                values: new object[,]
                {
                    { 1, "NEW", 1, 100 },
                    { 2, "RETURN", 2, 5 },
                    { 3, "BF2021", 3, 10 },
                    { 4, "No Discount", 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { 1, "john.smith@js.com", "John", "Smith" });

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
