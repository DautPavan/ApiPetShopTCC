using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_EmpresaIDXEmpresa_Id",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_FuncionarioIDXFuncionario_Id",
                table: "Agendas");

            migrationBuilder.RenameIndex(
                name: "I_Agendas_EmpresaId",
                table: "Agendas",
                newName: "IX_Agendas_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DonoId",
                table: "Agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Agendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Empresas_EmpresaId",
                table: "Agendas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Empresas_EmpresaId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Funcionarios_FuncionarioId",
                table: "Agendas");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_EmpresaId",
                table: "Agendas",
                newName: "I_Agendas_EmpresaId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonoId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Agendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_EmpresaIDXEmpresa_Id",
                table: "Agendas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_FuncionarioIDXFuncionario_Id",
                table: "Agendas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
