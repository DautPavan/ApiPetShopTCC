using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
