using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddedDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");
        }
    }
}
