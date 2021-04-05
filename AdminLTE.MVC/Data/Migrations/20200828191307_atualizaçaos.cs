using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class atualizaçaos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CondominioId",
                table: "AguaApartamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AguaApartamento_CondominioId",
                table: "AguaApartamento",
                column: "CondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AguaApartamento_Condominio_CondominioId",
                table: "AguaApartamento",
                column: "CondominioId",
                principalTable: "Condominio",
                principalColumn: "CondominioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AguaApartamento_Condominio_CondominioId",
                table: "AguaApartamento");

            migrationBuilder.DropIndex(
                name: "IX_AguaApartamento_CondominioId",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "AguaApartamento");
        }
    }
}
