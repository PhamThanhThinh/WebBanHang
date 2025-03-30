using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanHang.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Comic" },
                    { 2, "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 2, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 3, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 4, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 5, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 6, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 7, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 8, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 9, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 10, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 },
                    { 11, 1, "In order to survive the fiery Pyromeths, Martha Jones must spin three sensational yarns about the Tenth Doctor and his greatest adventures with old and new foes alike!", "/Images/Comic/91oVGuZABHL._SL1500_.jpg", "Doctor Who: Once Upon A Time Lord", 16m, 50 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "b" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
