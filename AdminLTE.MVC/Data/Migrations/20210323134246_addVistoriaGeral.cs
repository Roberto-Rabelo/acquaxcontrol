using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class addVistoriaGeral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemServicoGeral",
                columns: table => new
                {
                    OrdemVistoriaGeralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dt_solicitacao = table.Column<DateTime>(nullable: false),
                    dt_execucao = table.Column<DateTime>(nullable: false),
                    especificacao = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    emailCliente = table.Column<string>(nullable: true),
                    nomeCliente = table.Column<string>(nullable: true),
                    documento = table.Column<double>(nullable: false),
                    bloco = table.Column<int>(nullable: false),
                    unidade = table.Column<int>(nullable: false),
                    observacao = table.Column<string>(nullable: true),
                    IdAspNetUsers = table.Column<string>(nullable: true),
                    assinaturaCliente = table.Column<string>(nullable: true),
                    formaPagamento = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    pago = table.Column<double>(nullable: false),
                    FotoPath01 = table.Column<string>(nullable: true),
                    tipoVistoria = table.Column<string>(nullable: true),
                    condominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoGeral", x => x.OrdemVistoriaGeralId);
                    table.ForeignKey(
                        name: "FK_OrdemServicoGeral_Condominio_condominioId",
                        column: x => x.condominioId,
                        principalTable: "Condominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoGeral_condominioId",
                table: "OrdemServicoGeral",
                column: "condominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServicoGeral");
        }
    }
}
