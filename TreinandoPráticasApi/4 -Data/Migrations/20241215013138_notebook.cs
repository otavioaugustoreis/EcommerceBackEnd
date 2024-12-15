using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreinandoPráticasApi.Migrations
{
    /// <inheritdoc />
    public partial class notebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUTO_TB_CATEGORIA_fk_categoria",
                table: "TB_PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "fk_categoria",
                table: "TB_PRODUTO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUTO_TB_CATEGORIA_fk_categoria",
                table: "TB_PRODUTO",
                column: "fk_categoria",
                principalTable: "TB_CATEGORIA",
                principalColumn: "pk_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUTO_TB_CATEGORIA_fk_categoria",
                table: "TB_PRODUTO");

            migrationBuilder.AlterColumn<int>(
                name: "fk_categoria",
                table: "TB_PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUTO_TB_CATEGORIA_fk_categoria",
                table: "TB_PRODUTO",
                column: "fk_categoria",
                principalTable: "TB_CATEGORIA",
                principalColumn: "pk_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
