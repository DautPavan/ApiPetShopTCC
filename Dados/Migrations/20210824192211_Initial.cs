using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    RacaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PorteRaca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => x.RacaID);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    GeneroBiologico = table.Column<int>(type: "int", nullable: false),
                    PorteAnimal = table.Column<int>(type: "int", nullable: false),
                    RacaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_RacaIdXRaca_Id",
                        column: x => x.RacaId,
                        principalTable: "Racas",
                        principalColumn: "RacaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "I_Animais_Id",
                table: "Animais",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "I_Animais_Nome",
                table: "Animais",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "I_Animais_RacaId",
                table: "Animais",
                column: "RacaId");

            migrationBuilder.CreateIndex(
                name: "I_Racas_Id",
                table: "Racas",
                column: "RacaID");

            migrationBuilder.CreateIndex(
                name: "I_Racas_Nome",
                table: "Racas",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Racas");
        }
    }
}
