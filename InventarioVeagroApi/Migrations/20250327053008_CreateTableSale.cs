using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ide_cliente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dni = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "venta_detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_producto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    code_principal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    code_auxiliar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    venta_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta_detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_venta_detalle_venta_venta_id",
                        column: x => x.venta_id,
                        principalTable: "venta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venta_detalle_venta_id",
                table: "venta_detalle",
                column: "venta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venta_detalle");

            migrationBuilder.DropTable(
                name: "venta");
        }
    }
}
