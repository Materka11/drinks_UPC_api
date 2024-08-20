using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drinks_UPC_api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllNutritionalValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaturatedFat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carbohydrates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllNutritionalValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPC = table.Column<int>(type: "int", nullable: false),
                    EAN = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    JAN = table.Column<int>(type: "int", nullable: false),
                    ITF_14 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodeId = table.Column<int>(type: "int", nullable: false),
                    Composition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: true),
                    NutritionalValuesId = table.Column<int>(type: "int", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_AllNutritionalValues_NutritionalValuesId",
                        column: x => x.NutritionalValuesId,
                        principalTable: "AllNutritionalValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Barcodes_BarcodeId",
                        column: x => x.BarcodeId,
                        principalTable: "Barcodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drinks_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drinks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drinks_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ProducerId",
                table: "Brands",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_BarcodeId",
                table: "Drinks",
                column: "BarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_BrandId",
                table: "Drinks",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_CategoryId",
                table: "Drinks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_LabelId",
                table: "Drinks",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_NutritionalValuesId",
                table: "Drinks",
                column: "NutritionalValuesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "AllNutritionalValues");

            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
