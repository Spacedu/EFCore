using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    public partial class Mudanca05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartamentoUsuario_Usuarios_UsuariosId",
                table: "DepartamentoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosEntrega_Usuarios_UsuarioId",
                table: "EnderecosEntrega");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "TB_USUARIOS");

            migrationBuilder.RenameColumn(
                name: "RG",
                table: "TB_USUARIOS",
                newName: "REGISTRO_GERAL");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "TB_USUARIOS",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "TB_USUARIOS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_USUARIOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Matricula",
                table: "TB_USUARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_USUARIOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_TB_USUARIOS_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_UNICO",
                table: "TB_USUARIOS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_Nome_CPF",
                table: "TB_USUARIOS",
                columns: new[] { "Nome", "CPF" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIOS_UsuarioId",
                table: "TB_USUARIOS",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ColaboradorId",
                table: "Pedido",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_SupervisorId",
                table: "Pedido",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartamentoUsuario_TB_USUARIOS_UsuariosId",
                table: "DepartamentoUsuario",
                column: "UsuariosId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosEntrega_TB_USUARIOS_UsuarioId",
                table: "EnderecosEntrega",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USUARIOS_Contatos_UsuarioId",
                table: "TB_USUARIOS",
                column: "UsuarioId",
                principalTable: "Contatos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartamentoUsuario_TB_USUARIOS_UsuariosId",
                table: "DepartamentoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosEntrega_TB_USUARIOS_UsuarioId",
                table: "EnderecosEntrega");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USUARIOS_Contatos_UsuarioId",
                table: "TB_USUARIOS");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_EMAIL_UNICO",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_USUARIOS_Nome_CPF",
                table: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_USUARIOS_UsuarioId",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "TB_USUARIOS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_USUARIOS");

            migrationBuilder.RenameTable(
                name: "TB_USUARIOS",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "REGISTRO_GERAL",
                table: "Usuarios",
                newName: "RG");

            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Usuarios_UsuarioId",
                table: "Contatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartamentoUsuario_Usuarios_UsuariosId",
                table: "DepartamentoUsuario",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosEntrega_Usuarios_UsuarioId",
                table: "EnderecosEntrega",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
