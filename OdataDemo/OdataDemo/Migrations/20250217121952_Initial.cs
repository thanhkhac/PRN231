using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdataDemo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Cars" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Motorbikes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "Electronics" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "Cost", "ImageName", "ProductName", "Type" },
                values: new object[,]
                {
                    { 1, "VinFast", 1, 1900m, "VF9.jpg", "VinFast President", "Car" },
                    { 2, "Tesla", 1, 13000m, "ModelS.jpg", "Tesla Model S", "Car" },
                    { 3, "BMW", 1, 34999m, "X7.jpg", "BMW X7", "Car" },
                    { 4, "Mercedes-Benz", 1, 21000m, "GClass.jpg", "Mercedes-Benz G-Class", "Car" },
                    { 5, "Ford", 1, 11000m, "Mustang.jpg", "Ford Mustang", "Car" },
                    { 6, "Honda", 2, 16000m, "CBR1000RR.jpg", "Honda CBR1000RR", "Motorbike" },
                    { 7, "Yamaha", 2, 17000m, "R1.jpg", "Yamaha R1", "Motorbike" },
                    { 8, "Apple", 3, 2500m, "MacBookPro.jpg", "MacBook Pro 16", "Laptop" },
                    { 9, "Samsung", 3, 1200m, "GalaxyS23.jpg", "Samsung Galaxy S23 Ultra", "Smartphone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
