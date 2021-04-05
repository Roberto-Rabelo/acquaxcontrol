using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class ordem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdemservicoVistoriaId",
                table: "Condominio",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdemservicoVistoria",
                columns: table => new
                {
                    OrdemservicoVistoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dt_solicitacao = table.Column<DateTime>(nullable: false),
                    dt_execucao = table.Column<DateTime>(nullable: false),
                    condominioNovo = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    emailCliente = table.Column<string>(nullable: true),
                    hidrometroVencido = table.Column<string>(nullable: true),
                    baixaVazao = table.Column<string>(nullable: true),
                    torneiraCozinha = table.Column<string>(nullable: true),
                    torneiraTanque = table.Column<string>(nullable: true),
                    torneiraLavabo = table.Column<string>(nullable: true),
                    descargaLavabo = table.Column<string>(nullable: true),
                    chuveiroBanheiro01 = table.Column<string>(nullable: true),
                    torneiraBanheiro01 = table.Column<string>(nullable: true),
                    descargaBanheiro01 = table.Column<string>(nullable: true),
                    chuveiroBanheiro02 = table.Column<string>(nullable: true),
                    torneiraBanheiro02 = table.Column<string>(nullable: true),
                    descargaBanheiro02 = table.Column<string>(nullable: true),
                    chuveiroBanheiro03 = table.Column<string>(nullable: true),
                    torneiraBanheiro03 = table.Column<string>(nullable: true),
                    descargaBanheiro03 = table.Column<string>(nullable: true),
                    chuveiroBanheiro04 = table.Column<string>(nullable: true),
                    torneiraBanheiro04 = table.Column<string>(nullable: true),
                    descargaBanheiro04 = table.Column<string>(nullable: true),
                    FotoPath = table.Column<string>(nullable: true),
                    observacao = table.Column<string>(nullable: true),
                    IdAspNetUsers = table.Column<string>(nullable: true),
                    assinaturaCliente = table.Column<string>(nullable: true),
                    condominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemservicoVistoria", x => x.OrdemservicoVistoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_OrdemservicoVistoriaId",
                table: "Condominio",
                column: "OrdemservicoVistoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condominio_OrdemservicoVistoria_OrdemservicoVistoriaId",
                table: "Condominio",
                column: "OrdemservicoVistoriaId",
                principalTable: "OrdemservicoVistoria",
                principalColumn: "OrdemservicoVistoriaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominio_OrdemservicoVistoria_OrdemservicoVistoriaId",
                table: "Condominio");

            migrationBuilder.DropTable(
                name: "OrdemservicoVistoria");

            migrationBuilder.DropIndex(
                name: "IX_Condominio_OrdemservicoVistoriaId",
                table: "Condominio");

            migrationBuilder.DropColumn(
                name: "OrdemservicoVistoriaId",
                table: "Condominio");
        }
    }
}
