using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistics.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeconeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Orders",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");
        }
    }
}
