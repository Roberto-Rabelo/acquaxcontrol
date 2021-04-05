using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class mudancadetipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hidroAutomatico",
                table: "hidroAutomatico");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "hidroAutomatico");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "hidroAutomatico");

            migrationBuilder.RenameColumn(
                name: "Rawdata",
                table: "hidroAutomatico",
                newName: "rawdata");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "hidroAutomatico",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "hidroAutomatico",
                newName: "humidity");

            migrationBuilder.RenameColumn(
                name: "Counter03",
                table: "hidroAutomatico",
                newName: "counter03");

            migrationBuilder.RenameColumn(
                name: "Counter02",
                table: "hidroAutomatico",
                newName: "counter02");

            migrationBuilder.RenameColumn(
                name: "Counter01",
                table: "hidroAutomatico",
                newName: "counter01");

            migrationBuilder.RenameColumn(
                name: "Battery",
                table: "hidroAutomatico",
                newName: "battery");

            migrationBuilder.AddColumn<string>(
                name: "device",
                table: "hidroAutomatico",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "temperature",
                table: "hidroAutomatico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_hidroAutomatico",
                table: "hidroAutomatico",
                column: "device");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hidroAutomatico",
                table: "hidroAutomatico");

            migrationBuilder.DropColumn(
                name: "device",
                table: "hidroAutomatico");

            migrationBuilder.DropColumn(
                name: "temperature",
                table: "hidroAutomatico");

            migrationBuilder.RenameColumn(
                name: "rawdata",
                table: "hidroAutomatico",
                newName: "Rawdata");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "hidroAutomatico",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "humidity",
                table: "hidroAutomatico",
                newName: "Humidity");

            migrationBuilder.RenameColumn(
                name: "counter03",
                table: "hidroAutomatico",
                newName: "Counter03");

            migrationBuilder.RenameColumn(
                name: "counter02",
                table: "hidroAutomatico",
                newName: "Counter02");

            migrationBuilder.RenameColumn(
                name: "counter01",
                table: "hidroAutomatico",
                newName: "Counter01");

            migrationBuilder.RenameColumn(
                name: "battery",
                table: "hidroAutomatico",
                newName: "Battery");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "hidroAutomatico",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Temperatura",
                table: "hidroAutomatico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_hidroAutomatico",
                table: "hidroAutomatico",
                column: "DeviceId");
        }
    }
}
