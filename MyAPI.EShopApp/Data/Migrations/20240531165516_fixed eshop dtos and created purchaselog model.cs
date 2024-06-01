using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.EShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedeshopdtosandcreatedpurchaselogmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchaseLog");

            migrationBuilder.RenameColumn(
                name: "Totalamount",
                table: "PurchaseLogs",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Extrafees",
                table: "PurchaseLogs",
                newName: "ExtraFees");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "PurchaseLogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseLogProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PurchaseLogId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PurchasedQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLogProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseLogProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseLogProduct_PurchaseLogs_PurchaseLogId",
                        column: x => x.PurchaseLogId,
                        principalTable: "PurchaseLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_ProductId",
                table: "PurchaseLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogProduct_ProductId",
                table: "PurchaseLogProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogProduct_PurchaseLogId",
                table: "PurchaseLogProduct",
                column: "PurchaseLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogs_Products_ProductId",
                table: "PurchaseLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogs_Products_ProductId",
                table: "PurchaseLogs");

            migrationBuilder.DropTable(
                name: "PurchaseLogProduct");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseLogs_ProductId",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PurchaseLogs");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "PurchaseLogs",
                newName: "Totalamount");

            migrationBuilder.RenameColumn(
                name: "ExtraFees",
                table: "PurchaseLogs",
                newName: "Extrafees");

            migrationBuilder.CreateTable(
                name: "ProductPurchaseLog",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PurchaseLogsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchaseLog", x => new { x.ProductsId, x.PurchaseLogsId });
                    table.ForeignKey(
                        name: "FK_ProductPurchaseLog_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchaseLog_PurchaseLogs_PurchaseLogsId",
                        column: x => x.PurchaseLogsId,
                        principalTable: "PurchaseLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseLog_PurchaseLogsId",
                table: "ProductPurchaseLog",
                column: "PurchaseLogsId");
        }
    }
}
