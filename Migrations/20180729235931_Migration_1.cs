using Microsoft.EntityFrameworkCore.Migrations;

namespace softstoreapi.Migrations
{
    public partial class Migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Impostos_TiposProduto_TipoProdutoId",
                table: "Impostos");

            migrationBuilder.DropIndex(
                name: "IX_Impostos_TipoProdutoId",
                table: "Impostos");

            migrationBuilder.DropColumn(
                name: "TipoProdutoId",
                table: "Impostos");

            migrationBuilder.AddColumn<string>(
                name: "CodigoBarras",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoProdutoImposto",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(nullable: false),
                    ImpostoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProdutoImposto", x => new { x.TipoProdutoId, x.ImpostoId });
                    table.ForeignKey(
                        name: "FK_TipoProdutoImposto_Impostos_ImpostoId",
                        column: x => x.ImpostoId,
                        principalTable: "Impostos",
                        principalColumn: "ImpostoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoProdutoImposto_TiposProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TiposProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoProdutoImposto_ImpostoId",
                table: "TipoProdutoImposto",
                column: "ImpostoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoProdutoImposto");

            migrationBuilder.DropColumn(
                name: "CodigoBarras",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "TipoProdutoId",
                table: "Impostos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Impostos_TipoProdutoId",
                table: "Impostos",
                column: "TipoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Impostos_TiposProduto_TipoProdutoId",
                table: "Impostos",
                column: "TipoProdutoId",
                principalTable: "TiposProduto",
                principalColumn: "TipoProdutoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
