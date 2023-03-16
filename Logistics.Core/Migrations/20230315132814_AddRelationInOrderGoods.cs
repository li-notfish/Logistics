using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistics.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationInOrderGoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Goodes",
                type: "varchar(64)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goodes_OrderId",
                table: "Goodes",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes");

            migrationBuilder.DropIndex(
                name: "IX_Goodes_OrderId",
                table: "Goodes");

            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Goodes");
        }
    }
}
