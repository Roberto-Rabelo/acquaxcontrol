using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class atualizaçao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartamento_Condominio_CondominioId",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "BlocoId",
                table: "Apartamento");

            migrationBuilder.AlterColumn<int>(
                name: "CondominioId",
                table: "Apartamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlocosId",
                table: "Apartamento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento",
                column: "BlocosId",
                principalTable: "Bloco",
                principalColumn: "BlocosId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamento_Condominio_CondominioId",
                table: "Apartamento",
                column: "CondominioId",
                principalTable: "Condominio",
                principalColumn: "CondominioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartamento_Condominio_CondominioId",
                table: "Apartamento");

            migrationBuilder.AlterColumn<int>(
                name: "CondominioId",
                table: "Apartamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlocosId",
                table: "Apartamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BlocoId",
                table: "Apartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento",
                column: "BlocosId",
                principalTable: "Bloco",
                principalColumn: "BlocosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamento_Condominio_CondominioId",
                table: "Apartamento",
                column: "CondominioId",
                principalTable: "Condominio",
                principalColumn: "CondominioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
