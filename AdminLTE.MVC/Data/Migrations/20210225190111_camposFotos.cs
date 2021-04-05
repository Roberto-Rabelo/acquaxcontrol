using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class camposFotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPath1",
                table: "OrdemservicoVistoria",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPath3",
                table: "OrdemservicoVistoria",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPath4",
                table: "OrdemservicoVistoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPath1",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropColumn(
                name: "FotoPath3",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropColumn(
                name: "FotoPath4",
                table: "OrdemservicoVistoria");
        }
    }
}
