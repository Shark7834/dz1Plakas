using Microsoft.EntityFrameworkCore.Migrations;

namespace dz1Plakas.Data.Migrations
{
    public partial class ColorProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "colorProducts",
                columns: table => new
                {
                    colorid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colorProducts", x => new { x.colorid, x.productid });
                    table.ForeignKey(
                        name: "FK_colorProducts_colors_colorid",
                        column: x => x.colorid,
                        principalTable: "colors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_colorProducts_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_colorProducts_productid",
                table: "colorProducts",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colorProducts");

            migrationBuilder.DropTable(
                name: "colors");
        }
    }
}
