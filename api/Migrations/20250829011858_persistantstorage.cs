using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class persistantstorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Diff",
                table: "Teams",
                type: "int",
                nullable: false,
                computedColumnSql: "[GF] - [GC]",
                stored: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "[GF] - [GC]",
                oldStored: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Diff",
                table: "Teams",
                type: "int",
                nullable: false,
                computedColumnSql: "[GF] - [GC]",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "[GF] - [GC]");
        }
    }
}
