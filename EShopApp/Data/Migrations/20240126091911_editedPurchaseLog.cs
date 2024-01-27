using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.EShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class editedPurchaseLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogs_Products_ProductId",
                table: "PurchaseLogs");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseLogs_ProductId",
                table: "PurchaseLogs");

            migrationBuilder.RenameColumn(
                name: "datetime",
                table: "PurchaseLogs",
                newName: "Totalamount");

            migrationBuilder.RenameColumn(
                name: "accepted",
                table: "PurchaseLogs",
                newName: "IsAccepted");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PurchaseLogs",
                newName: "Extrafees");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutOn",
                table: "PurchaseLogs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseLogId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45ee830f-a1f3-44ad-8112-982ef324dab4"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4679e631-8273-49cd-91a6-fae714ea9d73"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4eaf8297-449c-4aea-a656-a92b8730a201"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4fe905ac-63ae-4e9c-a10f-b6379b594c18"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("710df7a2-9cf9-4b80-89d5-20be76a621af"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b199f9b1-cf03-4990-876e-492df1cf69d1"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f4411dd9-d96a-4104-9d33-30f7beb3ad05"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f741ceca-8eed-40a6-8706-3181886a2e23"),
                column: "PurchaseLogId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseLogId",
                table: "Products",
                column: "PurchaseLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PurchaseLogs_PurchaseLogId",
                table: "Products",
                column: "PurchaseLogId",
                principalTable: "PurchaseLogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PurchaseLogs_PurchaseLogId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseLogId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CheckoutOn",
                table: "PurchaseLogs");

            migrationBuilder.DropColumn(
                name: "PurchaseLogId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Totalamount",
                table: "PurchaseLogs",
                newName: "datetime");

            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "PurchaseLogs",
                newName: "accepted");

            migrationBuilder.RenameColumn(
                name: "Extrafees",
                table: "PurchaseLogs",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_ProductId",
                table: "PurchaseLogs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogs_Products_ProductId",
                table: "PurchaseLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
