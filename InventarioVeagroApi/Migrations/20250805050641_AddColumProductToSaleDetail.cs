using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumProductToSaleDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "producto_id",
                table: "venta_detalle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_detalle_producto_id",
                table: "venta_detalle",
                column: "producto_id");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_detalle_Products_producto_id",
                table: "venta_detalle",
                column: "producto_id",
                principalTable: "Products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_detalle_Products_producto_id",
                table: "venta_detalle");

            migrationBuilder.DropIndex(
                name: "IX_venta_detalle_producto_id",
                table: "venta_detalle");

            migrationBuilder.DropColumn(
                name: "producto_id",
                table: "venta_detalle");
        }
    }
}
