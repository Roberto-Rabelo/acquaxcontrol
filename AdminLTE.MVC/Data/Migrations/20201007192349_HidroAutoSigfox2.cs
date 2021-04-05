using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class HidroAutoSigfox2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hidroSigfox");

            migrationBuilder.CreateTable(
                name: "hidroAutoSigfox",
                columns: table => new
                {
                    HidroAutoSigfoxId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<int>(nullable: false),
                    device = table.Column<string>(maxLength: 150, nullable: false),
                    nome = table.Column<string>(maxLength: 150, nullable: true),
                    rawdata = table.Column<string>(maxLength: 150, nullable: true),
                    battery = table.Column<int>(nullable: false),
                    temperature = table.Column<int>(nullable: false),
                    humidity = table.Column<int>(nullable: false),
                    counter01 = table.Column<int>(nullable: false),
                    counter02 = table.Column<int>(nullable: false),
                    counter03 = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hidroAutoSigfox", x => x.HidroAutoSigfoxId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hidroAutoSigfox");

            migrationBuilder.CreateTable(
                name: "hidroSigfox",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    battery = table.Column<int>(type: "int", nullable: false),
                    counter01 = table.Column<int>(type: "int", nullable: false),
                    counter02 = table.Column<int>(type: "int", nullable: false),
                    counter03 = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<int>(type: "int", nullable: false),
                    device = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    rawdata = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    temperature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hidroSigfox", x => x.id);
                });
        }
    }
}
