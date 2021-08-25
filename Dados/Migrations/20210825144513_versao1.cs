using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animais",
                newName: "AnimalID");

            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    DonoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.DonoID);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    telefoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefones", x => x.telefoneID);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoID);
                    table.ForeignKey(
                        name: "FK_Contato_DonoIdXDono_ID",
                        column: x => x.DonoId,
                        principalTable: "Donos",
                        principalColumn: "DonoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonosAnimais",
                columns: table => new
                {
                    DonoId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonosAnimais", x => new { x.AnimalId, x.DonoId });
                    table.ForeignKey(
                        name: "FK_DonoAnimal_AnimalIdXAnimais_ID",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonoAnimal_DonoIdXDonos_ID",
                        column: x => x.DonoId,
                        principalTable: "Donos",
                        principalColumn: "DonoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContatosTelefones",
                columns: table => new
                {
                    ContatoTelefoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneId = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContatosTelefonesID", x => x.ContatoTelefoneID);
                    table.ForeignKey(
                        name: "FK_ContatosTelefones_ContatoIDXTelefone_Id",
                        column: x => x.ContatoId,
                        principalTable: "Contatos",
                        principalColumn: "ContatoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContatosTelefones_IDXTelefone_Id",
                        column: x => x.TelefoneId,
                        principalTable: "Telefones",
                        principalColumn: "telefoneID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "I_Contatos_DonoPK",
                table: "Contatos",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "I_Contatos_Id",
                table: "Contatos",
                column: "ContatoID");

            migrationBuilder.CreateIndex(
                name: "I_ContatosTelefones_Id",
                table: "ContatosTelefones",
                column: "ContatoTelefoneID");

            migrationBuilder.CreateIndex(
                name: "I_ContatosTelefones_TelefoneId",
                table: "ContatosTelefones",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ContatosTelefones_ContatoId",
                table: "ContatosTelefones",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "I_Donos_Id",
                table: "Donos",
                column: "DonoID");

            migrationBuilder.CreateIndex(
                name: "I_Donos_Nome",
                table: "Donos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "I_DonosAnimais_IdAnimal",
                table: "DonosAnimais",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "I_DonosAnimais_IdDono",
                table: "DonosAnimais",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "I_telefones_Id",
                table: "Telefones",
                column: "telefoneID");

            migrationBuilder.CreateIndex(
                name: "I_telefones_Numero",
                table: "Telefones",
                column: "Numero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContatosTelefones");

            migrationBuilder.DropTable(
                name: "DonosAnimais");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Donos");

            migrationBuilder.RenameColumn(
                name: "AnimalID",
                table: "Animais",
                newName: "Id");
        }
    }
}
