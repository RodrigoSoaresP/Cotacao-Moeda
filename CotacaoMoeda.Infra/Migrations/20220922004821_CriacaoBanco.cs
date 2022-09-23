using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CotacaoMoeda.Infra.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    DataHoraCotacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
