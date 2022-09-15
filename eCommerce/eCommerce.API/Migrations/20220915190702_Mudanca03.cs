using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    public partial class Mudanca03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomePai",
                table: "Usuarios",
                newName: "NomeDoPai");

            migrationBuilder.RenameColumn(
                name: "NomeMae",
                table: "Usuarios",
                newName: "NomeDaMae");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeDoPai",
                table: "Usuarios",
                newName: "NomePai");

            migrationBuilder.RenameColumn(
                name: "NomeDaMae",
                table: "Usuarios",
                newName: "NomeMae");
        }
    }
}
