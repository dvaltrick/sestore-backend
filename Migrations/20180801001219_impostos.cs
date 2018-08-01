using Microsoft.EntityFrameworkCore.Migrations;

namespace softstoreapi.Migrations
{
    public partial class impostos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TotalImpostos",
                table: "Vendas",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalImpostos",
                table: "ItemVenda",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalImpostos",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "TotalImpostos",
                table: "ItemVenda");
        }
    }
}
