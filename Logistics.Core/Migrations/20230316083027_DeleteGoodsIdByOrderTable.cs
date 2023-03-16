using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistics.Core.Migrations
{
    /// <inheritdoc />
    public partial class DeleteGoodsIdByOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);
        }
    }
}
