using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistics.Core.Migrations
{
    /// <inheritdoc />
    public partial class fixForKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WareHouseGoods_Goodes_GoodsId",
                table: "WareHouseGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouseGoods_Warehouses_WarehouseId",
                table: "WareHouseGoods");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouseGoods_Goodes_GoodsId",
                table: "WareHouseGoods",
                column: "GoodsId",
                principalTable: "Goodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouseGoods_Warehouses_WarehouseId",
                table: "WareHouseGoods",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WareHouseGoods_Goodes_GoodsId",
                table: "WareHouseGoods");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouseGoods_Warehouses_WarehouseId",
                table: "WareHouseGoods");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouseGoods_Goodes_GoodsId",
                table: "WareHouseGoods",
                column: "GoodsId",
                principalTable: "Goodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouseGoods_Warehouses_WarehouseId",
                table: "WareHouseGoods",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
