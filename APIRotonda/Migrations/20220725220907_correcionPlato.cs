using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRotonda.Migrations
{
    public partial class correcionPlato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plato_TipoPlato_tipoPlatoid",
                table: "Plato");

            migrationBuilder.DropIndex(
                name: "IX_Plato_tipoPlatoid",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "tipoPlatoid",
                table: "Plato");

            migrationBuilder.CreateIndex(
                name: "IX_Plato_fkTipo",
                table: "Plato",
                column: "fkTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Plato_TipoPlato_fkTipo",
                table: "Plato",
                column: "fkTipo",
                principalTable: "TipoPlato",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plato_TipoPlato_fkTipo",
                table: "Plato");

            migrationBuilder.DropIndex(
                name: "IX_Plato_fkTipo",
                table: "Plato");

            migrationBuilder.AddColumn<int>(
                name: "tipoPlatoid",
                table: "Plato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plato_tipoPlatoid",
                table: "Plato",
                column: "tipoPlatoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Plato_TipoPlato_tipoPlatoid",
                table: "Plato",
                column: "tipoPlatoid",
                principalTable: "TipoPlato",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
