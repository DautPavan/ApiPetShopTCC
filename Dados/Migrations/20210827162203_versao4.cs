using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PorteAnimal",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RacaId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AgendaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    DonoId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas_ID", x => x.AgendaID);
                    table.ForeignKey(
                        name: "FK_Agendas_AnimalIDXAnimal_Id",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_DonoIDXDono_Id",
                        column: x => x.DonoId,
                        principalTable: "Donos",
                        principalColumn: "DonoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_EmpresaIDXEmpresa_Id",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_FuncionarioIDXFuncionario_Id",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_ServicoIDXServico_Id",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "ServicoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_RacaId",
                table: "Servicos",
                column: "RacaId");

            migrationBuilder.CreateIndex(
                name: "I_Agendas_AnimalId",
                table: "Agendas",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "I_Agendas_DonoId",
                table: "Agendas",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "I_Agendas_EmpresaId",
                table: "Agendas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "I_Agendas_Id",
                table: "Agendas",
                column: "AgendaID");

            migrationBuilder.CreateIndex(
                name: "I_Agendas_ServicoId",
                table: "Agendas",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_FuncionarioId",
                table: "Agendas",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos",
                column: "RacaId",
                principalTable: "Racas",
                principalColumn: "RacaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Racas_RacaId",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_RacaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "PorteAnimal",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "RacaId",
                table: "Servicos");
        }
    }
}
