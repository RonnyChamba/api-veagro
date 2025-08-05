using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumSaleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ide_user",
                table: "venta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_ide_user",
                table: "venta",
                column: "ide_user");

            migrationBuilder.AddForeignKey(
                name: "FK_venta_Users_ide_user",
                table: "venta",
                column: "ide_user",
                principalTable: "Users",
                principalColumn: "ide");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_venta_Users_ide_user",
                table: "venta");

            migrationBuilder.DropIndex(
                name: "IX_venta_ide_user",
                table: "venta");

            migrationBuilder.DropColumn(
                name: "ide_user",
                table: "venta");
        }
    }
}
