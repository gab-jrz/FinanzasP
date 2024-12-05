using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanzasPersonales.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreToGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Detalle",
                table: "Gastos",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Gastos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Gastos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Gastos",
                newName: "Detalle");
        }
    }
}
