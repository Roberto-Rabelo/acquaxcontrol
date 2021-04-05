using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "re_leitura_atual",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "re_valor_atual",
                table: "AguaApartamento");

            migrationBuilder.AddColumn<int>(
                name: "Unidade",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "area_comum",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "bloco",
                table: "AguaApartamento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_leitura_anterior",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_leitura_proxima",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "mes_anterior",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "mes_atual",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total_unidade",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "vlr_agua",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "vlr_esgoto",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "volume_consumido",
                table: "AguaApartamento",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "area_comum",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "bloco",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "dt_leitura_anterior",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "dt_leitura_proxima",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "mes_anterior",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "mes_atual",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "total_unidade",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "vlr_agua",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "vlr_esgoto",
                table: "AguaApartamento");

            migrationBuilder.DropColumn(
                name: "volume_consumido",
                table: "AguaApartamento");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "AguaApartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "AguaApartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "re_leitura_atual",
                table: "AguaApartamento",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "re_valor_atual",
                table: "AguaApartamento",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
