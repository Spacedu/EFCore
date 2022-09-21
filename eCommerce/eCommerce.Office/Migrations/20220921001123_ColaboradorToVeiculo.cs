using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    public partial class ColaboradorToVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradoresId",
                table: "ColaboradorVeiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculosId",
                table: "ColaboradorVeiculo");

            migrationBuilder.RenameColumn(
                name: "VeiculosId",
                table: "ColaboradorVeiculo",
                newName: "VeiculoId");

            migrationBuilder.RenameColumn(
                name: "ColaboradoresId",
                table: "ColaboradorVeiculo",
                newName: "ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_ColaboradorVeiculo_VeiculosId",
                table: "ColaboradorVeiculo",
                newName: "IX_ColaboradorVeiculo_VeiculoId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DataInicioDeVinculo",
                table: "ColaboradorVeiculo",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6134), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6193), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6198), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6195), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6200), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6206), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 21, 11, 22, 276, DateTimeKind.Unspecified).AddTicks(6209), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "Id", "Nome", "Placa" },
                values: new object[,]
                {
                    { 1, "FIAT - Argo", "ABC-1234" },
                    { 2, "FIAT - Mobi", "DFG-1234" },
                    { 3, "FIAT - Sienna", "HIJ-1234" },
                    { 4, "FIAT - Idea", "LMN-1234" },
                    { 5, "FIAT - Toro", "OPQ-1234" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradorId",
                table: "ColaboradorVeiculo",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculoId",
                table: "ColaboradorVeiculo",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradorId",
                table: "ColaboradorVeiculo");

            migrationBuilder.DropForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculoId",
                table: "ColaboradorVeiculo");

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Veiculos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "DataInicioDeVinculo",
                table: "ColaboradorVeiculo");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "ColaboradorVeiculo",
                newName: "VeiculosId");

            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "ColaboradorVeiculo",
                newName: "ColaboradoresId");

            migrationBuilder.RenameIndex(
                name: "IX_ColaboradorVeiculo_VeiculoId",
                table: "ColaboradorVeiculo",
                newName: "IX_ColaboradorVeiculo_VeiculosId");

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 1, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 6, 1 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4685), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 4, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4690), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 5, 2 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4688), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 7, 3 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4692), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 2, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4694), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "ColaboradoresSetores",
                keyColumns: new[] { "ColaboradorId", "SetorId" },
                keyValues: new object[] { 3, 4 },
                column: "Criado",
                value: new DateTimeOffset(new DateTime(2022, 9, 20, 18, 49, 21, 440, DateTimeKind.Unspecified).AddTicks(4697), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Colaboradores_ColaboradoresId",
                table: "ColaboradorVeiculo",
                column: "ColaboradoresId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColaboradorVeiculo_Veiculos_VeiculosId",
                table: "ColaboradorVeiculo",
                column: "VeiculosId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
