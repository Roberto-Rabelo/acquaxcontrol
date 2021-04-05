using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class blap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bloco",
                table: "OrdemservicoVistoria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unidade",
                table: "OrdemservicoVistoria",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bloco",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropColumn(
                name: "unidade",
                table: "OrdemservicoVistoria");
        }
    }
}
