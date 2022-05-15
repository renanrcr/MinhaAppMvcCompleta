using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCR.Data.Migrations
{
    public partial class AdicionandoCampoValorTabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Produtos");
        }
    }
}
