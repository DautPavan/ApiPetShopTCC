using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class versao7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoUnit",
                table: "Produtos",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(double),
                oldType: "float(16)",
                oldPrecision: 16,
                oldScale: 2,
                oldDefaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecoUnit",
                table: "Produtos",
                type: "float(16)",
                precision: 16,
                scale: 2,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldDefaultValue: 0m);
        }
    }
}
