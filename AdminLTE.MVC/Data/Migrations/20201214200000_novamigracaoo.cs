using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class novamigracaoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hidrometro",
                columns: table => new
                {
                    HidrometroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroHidrometro = table.Column<double>(nullable: false),
                    pulsoHidrometro = table.Column<double>(nullable: false),
                    Acumulador = table.Column<double>(nullable: false),
                    Device = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hidrometro", x => x.HidrometroId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hidrometro");
        }
    }
}
