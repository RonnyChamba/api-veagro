using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFielAuditoriaProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "measurementUnit",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "recordStatus",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Activo");

            migrationBuilder.AddColumn<decimal>(
                name: "stockAvailable",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "measurementUnit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "recordStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "stockAvailable",
                table: "Products");
        }
    }
}
