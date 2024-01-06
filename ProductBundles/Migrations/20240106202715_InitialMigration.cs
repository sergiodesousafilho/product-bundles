using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductBundles.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bundle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BundleRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ParentBundleId = table.Column<int>(type: "int", nullable: false),
                    ChildBundleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleRelation_Bundle_ChildBundleId",
                        column: x => x.ChildBundleId,
                        principalTable: "Bundle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BundleRelation_Bundle_ParentBundleId",
                        column: x => x.ParentBundleId,
                        principalTable: "Bundle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BundleProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BundleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BundleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BundleProduct_Bundle_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BundleProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BundleProduct_BundleId",
                table: "BundleProduct",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleProduct_ProductId",
                table: "BundleProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleRelation_ChildBundleId",
                table: "BundleRelation",
                column: "ChildBundleId");

            migrationBuilder.CreateIndex(
                name: "IX_BundleRelation_ParentBundleId",
                table: "BundleRelation",
                column: "ParentBundleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BundleProduct");

            migrationBuilder.DropTable(
                name: "BundleRelation");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Bundle");
        }
    }
}
