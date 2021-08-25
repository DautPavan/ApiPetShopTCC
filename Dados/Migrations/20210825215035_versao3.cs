using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerenteId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios_ID", x => x.FuncionarioID);
                    table.ForeignKey(
                        name: "FK_Funcionarios_EmpresaIDXEmpresa_ID",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_IDXFuncionarios_GerenteID",
                        column: x => x.GerenteId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "I_Funcionarios_GerenteId",
                table: "Funcionarios",
                column: "GerenteId");

            migrationBuilder.CreateIndex(
                name: "I_Funcionarios_Id",
                table: "Funcionarios",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "I_Funcionarios_NomeCompleto",
                table: "Funcionarios",
                column: "NomeCompleto");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresaId",
                table: "Funcionarios",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
