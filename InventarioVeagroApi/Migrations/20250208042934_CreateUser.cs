using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ide = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_record = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_account = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ide);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_dni",
                table: "Users",
                column: "dni",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
