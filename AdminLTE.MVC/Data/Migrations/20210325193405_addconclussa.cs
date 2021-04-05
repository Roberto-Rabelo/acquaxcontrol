using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class addconclussa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "conclusao",
                table: "OrdemservicoVistoria",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "OrdemservicoVistoria",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conclusao",
                table: "OrdemservicoVistoria");

            migrationBuilder.DropColumn(
                name: "status",
                table: "OrdemservicoVistoria");
        }
    }
}
