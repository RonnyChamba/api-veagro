using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameColumn(
                name: "auxiliaryCode",
                table: "Products",
                newName: "auxiliary_code");


            migrationBuilder.RenameColumn(
              name: "mainCode",
              table: "Products",
              newName: "main_code");

            migrationBuilder.RenameColumn(
             name: "createDate",
             table: "Products",
             newName: "create_date");

            migrationBuilder.RenameColumn(
             name: "measurementUnit",
             table: "Products",
             newName: "measurement_unit");

            migrationBuilder.RenameColumn(
             name: "recordStatus",
             table: "Products",
             newName: "record_status");

            migrationBuilder.RenameColumn(
             name: "stockAvailable",
             table: "Products",
             newName: "stock_available");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "auxiliary_code",
                table: "Products",
                newName: "auxiliaryCode");

            migrationBuilder.RenameColumn(
                name: "main_code",
                table: "Products",
                newName: "mainCode");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Products",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "measurement_unit",
                table: "Products",
                newName: "measurementUnit");

            migrationBuilder.RenameColumn(
                name: "record_status",
                table: "Products",
                newName: "recordStatus");

            migrationBuilder.RenameColumn(
                name: "stock_available",
                table: "Products",
                newName: "stockAvailable");
        }
    }
}
