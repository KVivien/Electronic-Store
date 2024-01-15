using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electronic_Store.Migrations
{
    public partial class Vendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "VendorID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_VendorID",
                table: "Product",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Vendor_VendorID",
                table: "Product",
                column: "VendorID",
                principalTable: "Vendor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Vendor_VendorID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Product_VendorID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
