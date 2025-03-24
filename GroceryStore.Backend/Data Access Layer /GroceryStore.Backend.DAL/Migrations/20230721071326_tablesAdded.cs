using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryStore.Backend.DAL.Migrations
{
    public partial class tablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CategoryDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<string>(type: "TEXT", nullable: false),
                    OrderedItems = table.Column<string>(type: "TEXT", nullable: false),
                    OrderedQuantity = table.Column<string>(type: "TEXT", nullable: false),
                    AmountInItem = table.Column<string>(type: "TEXT", nullable: false),
                    OrderAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTable",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductDiscount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductSpecification = table.Column<string>(type: "TEXT", nullable: false),
                    ProductImage = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTable", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductTable_CategoryTable_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "CategoryTable",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CartTable_ProductTable_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalTable: "ProductTable",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewTable",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReviewText = table.Column<string>(type: "TEXT", nullable: false),
                    ReviewRating = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewTable", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewTable_ProductTable_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalTable: "ProductTable",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54d2dfe3-d350-4354-b2f7-e2153bf63731", "AQAAAAEAACcQAAAAEBITKsx77FmGnXrX6AT82xPlJ1rfC+ebcN6i9Dr+MDLpFD/v8F0NGJ5YCYlYVzS30Q==", "6d72242e-0f20-4774-b844-a6fde3bc1809" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b92e9c17-5b49-4497-a680-656e5e1ff111", "AQAAAAEAACcQAAAAELo1KI5sGIhG/mFr8KK8XEkd7HxMIlNA0iHbLe8t192BdtLnalDN+/Ddvq9LPMngbg==", "6ef78268-838d-4878-bca0-6929c439672f" });

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_ProductEntityId",
                table: "CartTable",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_CategoryEntityId",
                table: "ProductTable",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewTable_ProductEntityId",
                table: "ReviewTable",
                column: "ProductEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartTable");

            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropTable(
                name: "ReviewTable");

            migrationBuilder.DropTable(
                name: "ProductTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32b16009-52c1-4ce5-8f98-ce50fb5d0596", "AQAAAAEAACcQAAAAEMuYWG/rjQlGuqTlIllLnIOWA7ojV68qUqND3UMdlYHN0I6VeWYaNy3wcot7OUa3pQ==", "d6ee0d9b-34dc-4ac5-b3b8-c00ad025d140" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "296b873a-d417-4c40-9062-89f43de9929d", "AQAAAAEAACcQAAAAEC/Q+2c4y49fd0b7cgr1l6eC8h9y5+Zr0AS/06k92pyCOB3NgsRuOZKfa11LscBNVw==", "dbf34997-4df6-49f8-8deb-fcebae2563d9" });
        }
    }
}
