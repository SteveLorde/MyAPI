using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.EShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedmodelsanddtosaddedmoredtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogProduct_Products_ProductId",
                table: "PurchaseLogProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogProduct_PurchaseLogs_PurchaseLogId",
                table: "PurchaseLogProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseLogProduct",
                table: "PurchaseLogProduct");

            migrationBuilder.RenameTable(
                name: "PurchaseLogProduct",
                newName: "PurchaseLogProducts");

            migrationBuilder.RenameColumn(
                name: "usertype",
                table: "Users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "profileimage",
                table: "Users",
                newName: "ProfileImage");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "hashedpassword",
                table: "Users",
                newName: "HashedPassword");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "pass_salt",
                table: "Users",
                newName: "PassSalt");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseLogProduct_PurchaseLogId",
                table: "PurchaseLogProducts",
                newName: "IX_PurchaseLogProducts_PurchaseLogId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseLogProduct_ProductId",
                table: "PurchaseLogProducts",
                newName: "IX_PurchaseLogProducts_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseLogProducts",
                table: "PurchaseLogProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"),
                column: "Address",
                value: "Ahmed El Zomor,Nasr City");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogProducts_Products_ProductId",
                table: "PurchaseLogProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogProducts_PurchaseLogs_PurchaseLogId",
                table: "PurchaseLogProducts",
                column: "PurchaseLogId",
                principalTable: "PurchaseLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogProducts_Products_ProductId",
                table: "PurchaseLogProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLogProducts_PurchaseLogs_PurchaseLogId",
                table: "PurchaseLogProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseLogProducts",
                table: "PurchaseLogProducts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "PurchaseLogProducts",
                newName: "PurchaseLogProduct");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "usertype");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "Users",
                newName: "profileimage");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "hashedpassword");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "PassSalt",
                table: "Users",
                newName: "pass_salt");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseLogProducts_PurchaseLogId",
                table: "PurchaseLogProduct",
                newName: "IX_PurchaseLogProduct_PurchaseLogId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseLogProducts_ProductId",
                table: "PurchaseLogProduct",
                newName: "IX_PurchaseLogProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseLogProduct",
                table: "PurchaseLogProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogProduct_Products_ProductId",
                table: "PurchaseLogProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLogProduct_PurchaseLogs_PurchaseLogId",
                table: "PurchaseLogProduct",
                column: "PurchaseLogId",
                principalTable: "PurchaseLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
