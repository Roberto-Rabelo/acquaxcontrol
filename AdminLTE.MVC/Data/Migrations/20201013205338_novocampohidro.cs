using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class novocampohidro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "hidroAutoSigfox",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "emailConvidado",
                table: "hidroAutoSigfox",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailConvidado",
                table: "hidroAutoSigfox");

            migrationBuilder.AlterColumn<int>(
                name: "data",
                table: "hidroAutoSigfox",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
