using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRotonda.Migrations
{
    public partial class baseDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroPedido = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccionEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fkCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_fkCliente",
                        column: x => x.fkCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePlato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fkRestaurante = table.Column<int>(type: "int", nullable: false),
                    fkTipo = table.Column<int>(type: "int", nullable: false),
                    tipoPlatoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plato", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plato_Restaurante_fkRestaurante",
                        column: x => x.fkRestaurante,
                        principalTable: "Restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plato_TipoPlato_tipoPlatoid",
                        column: x => x.tipoPlatoid,
                        principalTable: "TipoPlato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientePlato",
                columns: table => new
                {
                    fkPlato = table.Column<int>(type: "int", nullable: false),
                    fkIngrediente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePlato", x => new { x.fkIngrediente, x.fkPlato });
                    table.ForeignKey(
                        name: "FK_IngredientePlato_Ingrediente_fkIngrediente",
                        column: x => x.fkIngrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePlato_Plato_fkPlato",
                        column: x => x.fkPlato,
                        principalTable: "Plato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoPlato",
                columns: table => new
                {
                    fkPlato = table.Column<int>(type: "int", nullable: false),
                    fkPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPlato", x => new { x.fkPlato, x.fkPedido });
                    table.ForeignKey(
                        name: "FK_PedidoPlato_Pedido_fkPedido",
                        column: x => x.fkPedido,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoPlato_Plato_fkPlato",
                        column: x => x.fkPlato,
                        principalTable: "Plato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePlato_fkPlato",
                table: "IngredientePlato",
                column: "fkPlato");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_fkCliente",
                table: "Pedido",
                column: "fkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPlato_fkPedido",
                table: "PedidoPlato",
                column: "fkPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Plato_fkRestaurante",
                table: "Plato",
                column: "fkRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_Plato_tipoPlatoid",
                table: "Plato",
                column: "tipoPlatoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePlato");

            migrationBuilder.DropTable(
                name: "PedidoPlato");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Plato");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "TipoPlato");
        }
    }
}
