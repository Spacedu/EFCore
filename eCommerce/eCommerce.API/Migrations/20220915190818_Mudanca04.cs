using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    public partial class Mudanca04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoPai",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "NomeDaMae",
                table: "Usuarios",
                newName: "Mae");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mae",
                table: "Usuarios",
                newName: "NomeDaMae");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoPai",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
