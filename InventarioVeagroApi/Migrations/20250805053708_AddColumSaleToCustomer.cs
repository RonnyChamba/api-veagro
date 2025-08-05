using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumSaleToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ide_cliente",
                table: "venta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_venta_ide_cliente",
                table: "venta",
                column: "ide_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Customers_ide_cliente",
                table: "venta",
                column: "ide_cliente",
                principalTable: "Customers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_Customers_ide_cliente",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_venta_ide_cliente",
                table: "venta");

            migrationBuilder.AlterColumn<int>(
                name: "ide_cliente",
                table: "venta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
