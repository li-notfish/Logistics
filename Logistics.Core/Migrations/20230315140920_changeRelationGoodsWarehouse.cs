using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistics.Core.Migrations
{
    /// <inheritdoc />
    public partial class changeRelationGoodsWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes");

            migrationBuilder.DropTable(
                name: "WareHouseGoods");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Goodes",
                type: "varchar(64)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Goodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Goodes_WarehouseId",
                table: "Goodes",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goodes_Warehouses_WarehouseId",
                table: "Goodes",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Goodes_Warehouses_WarehouseId",
                table: "Goodes");

            migrationBuilder.DropIndex(
                name: "IX_Goodes_WarehouseId",
                table: "Goodes");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Goodes");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Goodes",
                type: "varchar(64)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.CreateTable(
                name: "WareHouseGoods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "INTEGER", nullable: false),
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseGoods", x => new { x.GoodsId, x.WarehouseId });
                    table.ForeignKey(
                        name: "FK_WareHouseGoods_Goodes_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WareHouseGoods_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WareHouseGoods_WarehouseId",
                table: "WareHouseGoods",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goodes_Orders_OrderId",
                table: "Goodes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
