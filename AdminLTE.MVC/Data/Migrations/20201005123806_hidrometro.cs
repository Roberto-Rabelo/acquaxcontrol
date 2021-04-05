using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class hidrometro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hidroAutomatico",
                columns: table => new
                {
                    DeviceId = table.Column<string>(maxLength: 150, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Rawdata = table.Column<string>(maxLength: 150, nullable: true),
                    Battery = table.Column<int>(nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    Counter01 = table.Column<int>(nullable: false),
                    Counter02 = table.Column<int>(nullable: false),
                    Counter03 = table.Column<int>(nullable: false),
                    ApartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hidroAutomatico", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_hidroAutomatico_Apartamento_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamento",
                        principalColumn: "ApartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hidroAutomatico_ApartamentoId",
                table: "hidroAutomatico",
                column: "ApartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hidroAutomatico");
        }
    }
}
