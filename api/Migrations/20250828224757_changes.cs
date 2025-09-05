using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PTS",
                table: "Teams",
                type: "int",
                nullable: false,
                computedColumnSql: "ISNULL([PG], 0) * 3 + ISNULL([PE], 0)",
                stored: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Diff",
                table: "Teams",
                type: "int",
                nullable: false,
                computedColumnSql: "[GF] - [GC]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DNI",
                table: "Players",
                column: "DNI",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_DNI",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "PTS",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "ISNULL([PG], 0) * 3 + ISNULL([PE], 0)");

            migrationBuilder.AlterColumn<int>(
                name: "Diff",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "[GF] - [GC]");
        }
    }
}
