using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthenticationId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthenticationId",
                table: "Donos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AuthenticationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_ID", x => x.AuthenticationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AuthenticationId",
                table: "Funcionarios",
                column: "AuthenticationId");

            migrationBuilder.CreateIndex(
                name: "IX_Donos_AuthenticationId",
                table: "Donos",
                column: "AuthenticationId");

            migrationBuilder.CreateIndex(
                name: "I_Authentication_Id",
                table: "Authentication",
                column: "AuthenticationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donos_AuthenticationIdXAuthentication_ID",
                table: "Donos",
                column: "AuthenticationId",
                principalTable: "Authentication",
                principalColumn: "AuthenticationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AuthenticationIdXAuthentication_ID",
                table: "Funcionarios",
                column: "AuthenticationId",
                principalTable: "Authentication",
                principalColumn: "AuthenticationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donos_AuthenticationIdXAuthentication_ID",
                table: "Donos");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AuthenticationIdXAuthentication_ID",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_AuthenticationId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Donos_AuthenticationId",
                table: "Donos");

            migrationBuilder.DropColumn(
                name: "AuthenticationId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "AuthenticationId",
                table: "Donos");
        }
    }
}
