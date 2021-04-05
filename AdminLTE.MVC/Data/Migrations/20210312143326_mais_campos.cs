using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class mais_campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "documento",
                table: "OrdemservicoVistoria",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nomeCliente",
                table: "OrdemservicoVistoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "documento",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropColumn(
                name: "nomeCliente",
                table: "OrdemservicoVistoria");
        }
    }
}
