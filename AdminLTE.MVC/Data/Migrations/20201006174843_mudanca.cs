using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class mudanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hidroAutomatico_Apartamento_ApartamentoId",
                table: "hidroAutomatico");

            migrationBuilder.DropIndex(
                name: "IX_hidroAutomatico_ApartamentoId",
                table: "hidroAutomatico");

            migrationBuilder.DropColumn(
                name: "ApartamentoId",
                table: "hidroAutomatico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartamentoId",
                table: "hidroAutomatico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_hidroAutomatico_ApartamentoId",
                table: "hidroAutomatico",
                column: "ApartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_hidroAutomatico_Apartamento_ApartamentoId",
                table: "hidroAutomatico",
                column: "ApartamentoId",
                principalTable: "Apartamento",
                principalColumn: "ApartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
