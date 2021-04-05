using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class string_for_int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominio_OrdemservicoVistoria_OrdemservicoVistoriaId",
                table: "Condominio");

            migrationBuilder.DropIndex(
                name: "IX_Condominio_OrdemservicoVistoriaId",
                table: "Condominio");

            migrationBuilder.DropColumn(
                name: "OrdemservicoVistoriaId",
                table: "Condominio");

            migrationBuilder.AlterColumn<int>(
                name: "condominioId",
                table: "OrdemservicoVistoria",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemservicoVistoria_condominioId",
                table: "OrdemservicoVistoria",
                column: "condominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemservicoVistoria_Condominio_condominioId",
                table: "OrdemservicoVistoria",
                column: "condominioId",
                principalTable: "Condominio",
                principalColumn: "CondominioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemservicoVistoria_Condominio_condominioId",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropIndex(
                name: "IX_OrdemservicoVistoria_condominioId",
                table: "OrdemservicoVistoria");

            migrationBuilder.AlterColumn<string>(
                name: "condominioId",
                table: "OrdemservicoVistoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrdemservicoVistoriaId",
                table: "Condominio",
                type: "int",
                nullable: true);

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
    }
}
