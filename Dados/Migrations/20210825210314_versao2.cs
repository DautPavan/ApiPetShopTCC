using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_DonoIdXDono_ID",
                table: "Contatos");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Contatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas_Id", x => x.EmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrecoUnit = table.Column<double>(type: "float(16)", precision: 16, scale: 2, nullable: false, defaultValue: 0.0),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos_Id", x => x.ProdutoID);
                    table.ForeignKey(
                        name: "FK_Produtos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Valor = table.Column<double>(type: "float(16)", precision: 16, scale: 2, nullable: false, defaultValue: 0.0),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos_Id", x => x.ServicoID);
                    table.ForeignKey(
                        name: "FK_Servicos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_EmpresaId",
                table: "Contatos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "I_Empresas_CNPJ",
                table: "Empresas",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "I_Empresas_Id",
                table: "Empresas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "I_Empresas_NomeEmpresa",
                table: "Empresas",
                column: "NomeEmpresa");

            migrationBuilder.CreateIndex(
                name: "I_Produtos_EmpresaId",
                table: "Produtos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "I_Produtos_Id",
                table: "Produtos",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "I_Produtos_Nome",
                table: "Produtos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "I_Servicos_EmpresaId",
                table: "Servicos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "I_Servicos_Id",
                table: "Servicos",
                column: "ServicoID");

            migrationBuilder.CreateIndex(
                name: "I_Servicos_NomeServico",
                table: "Servicos",
                column: "NomeServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_DonoIdXDono_ID",
                table: "Contatos",
                column: "DonoId",
                principalTable: "Donos",
                principalColumn: "DonoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Empresas_EmpresaId",
                table: "Contatos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_DonoIdXDono_ID",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Empresas_EmpresaId",
                table: "Contatos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_EmpresaId",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal_ID",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Contatos");

            migrationBuilder.AddPrimaryKey(
                name: "ID",
                table: "Animais",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_DonoIdXDono_ID",
                table: "Contatos",
                column: "DonoId",
                principalTable: "Donos",
                principalColumn: "DonoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
