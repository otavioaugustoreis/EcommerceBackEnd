using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreinandoPráticasApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoCerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fk_pedido",
                table: "TB_USUARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ds_imagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.pk_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fk_usuario = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_TB_USUARIO_fk_usuario",
                        column: x => x.fk_usuario,
                        principalTable: "TB_USUARIO",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nr_quantidade = table.Column<int>(type: "int", nullable: false),
                    fk_categoria = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_CATEGORIA_fk_categoria",
                        column: x => x.fk_categoria,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PEDIDOITEM",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nr_valor = table.Column<double>(type: "double", nullable: false),
                    nr_quantidade = table.Column<int>(type: "int", nullable: false),
                    fk_pedido = table.Column<int>(type: "int", nullable: false),
                    fk_produto = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDOITEM", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDOITEM_TB_PEDIDO_fk_pedido",
                        column: x => x.fk_pedido,
                        principalTable: "TB_PEDIDO",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDOITEM_TB_PRODUTO_fk_produto",
                        column: x => x.fk_produto,
                        principalTable: "TB_PRODUTO",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_fk_usuario",
                table: "TB_PEDIDO",
                column: "fk_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDOITEM_fk_pedido",
                table: "TB_PEDIDOITEM",
                column: "fk_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDOITEM_fk_produto",
                table: "TB_PEDIDOITEM",
                column: "fk_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_fk_categoria",
                table: "TB_PRODUTO",
                column: "fk_categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PEDIDOITEM");

            migrationBuilder.DropTable(
                name: "TB_PEDIDO");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");

            migrationBuilder.DropColumn(
                name: "fk_pedido",
                table: "TB_USUARIO");
        }
    }
}
