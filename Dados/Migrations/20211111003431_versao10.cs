using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "PorteAnimal",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Donos");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "Donos");

            migrationBuilder.RenameIndex(
                name: "I_Servicos_EmpresaId",
                table: "Servicos",
                newName: "IX_Servicos_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "RacaId",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos",
                column: "RacaId",
                principalTable: "Racas",
                principalColumn: "RacaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos");

            migrationBuilder.RenameIndex(
                name: "IX_Servicos_EmpresaId",
                table: "Servicos",
                newName: "I_Servicos_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "RacaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PorteAnimal",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Donos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Donos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos",
                column: "RacaId",
                principalTable: "Racas",
                principalColumn: "RacaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
