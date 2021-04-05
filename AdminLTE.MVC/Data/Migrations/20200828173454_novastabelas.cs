using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.MVC.Data.Migrations
{
    public partial class novastabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloco",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "apartamento",
                table: "Apartamento");

            migrationBuilder.AddColumn<int>(
                name: "BlocoId",
                table: "Apartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlocosId",
                table: "Apartamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdAspNetUsers",
                table: "Apartamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "apartamentos",
                table: "Apartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlocosId",
                table: "AguaCondominio",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bloco",
                columns: table => new
                {
                    BlocosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bloco = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true),
                    CondominioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloco", x => x.BlocosId);
                    table.ForeignKey(
                        name: "FK_Bloco_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "CondominioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamento_BlocosId",
                table: "Apartamento",
                column: "BlocosId");

            migrationBuilder.CreateIndex(
                name: "IX_AguaCondominio_BlocosId",
                table: "AguaCondominio",
                column: "BlocosId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloco_CondominioId",
                table: "Bloco",
                column: "CondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AguaCondominio_Bloco_BlocosId",
                table: "AguaCondominio",
                column: "BlocosId",
                principalTable: "Bloco",
                principalColumn: "BlocosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento",
                column: "BlocosId",
                principalTable: "Bloco",
                principalColumn: "BlocosId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AguaCondominio_Bloco_BlocosId",
                table: "AguaCondominio");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartamento_Bloco_BlocosId",
                table: "Apartamento");

            migrationBuilder.DropTable(
                name: "Bloco");

            migrationBuilder.DropIndex(
                name: "IX_Apartamento_BlocosId",
                table: "Apartamento");

            migrationBuilder.DropIndex(
                name: "IX_AguaCondominio_BlocosId",
                table: "AguaCondominio");

            migrationBuilder.DropColumn(
                name: "BlocoId",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "BlocosId",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "IdAspNetUsers",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "apartamentos",
                table: "Apartamento");

            migrationBuilder.DropColumn(
                name: "BlocosId",
                table: "AguaCondominio");

            migrationBuilder.AddColumn<string>(
                name: "Bloco",
                table: "Apartamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "apartamento",
                table: "Apartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
