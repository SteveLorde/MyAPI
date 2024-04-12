using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAPI.EShopApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    subtitle = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    startdate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    enddate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    discountamount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ispercentage = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    pass_salt = table.Column<string>(type: "TEXT", nullable: false),
                    hashedpassword = table.Column<string>(type: "TEXT", nullable: false),
                    usertype = table.Column<string>(type: "TEXT", nullable: false),
                    phonenumber = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    profileimage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MainCategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ParentCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CheckoutOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Extrafees = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Totalamount = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsShipped = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Barcode = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedOn = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Images = table.Column<string>(type: "TEXT", nullable: false),
                    Sells = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountEventProduct",
                columns: table => new
                {
                    DiscountEventsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEventProduct", x => new { x.DiscountEventsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DiscountEventProduct_DiscountEvents_DiscountEventsId",
                        column: x => x.DiscountEventsId,
                        principalTable: "DiscountEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountEventProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "DiscountEvents",
                columns: new[] { "Id", "description", "discountamount", "enddate", "image", "ispercentage", "startdate", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("0d8b8ff5-db08-4ee0-ae55-dd0267116b5d"), "Desc Test", 50m, new DateOnly(2024, 2, 18), "newscover.jpg", false, new DateOnly(2024, 1, 18), "null", "Christmas Discounts on Electronics" },
                    { new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"), "Desc Test", 50m, new DateOnly(2024, 2, 18), "newscover.jpg", false, new DateOnly(2024, 1, 18), "null", "Shop Smart, Save Big: Exclusive Year-End Sale with Unbeatable Discounts!" },
                    { new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), "Desc Test", 20m, new DateOnly(2024, 2, 18), "newscover.jpg", false, new DateOnly(2024, 1, 18), "null", "Digital Winter VideoGames Sales" }
                });

            migrationBuilder.InsertData(
                table: "ParentCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), "Electronics" },
                    { new Guid("6d8e2cc8-9c0f-11ee-8c90-0242ac120002"), "Groceries" },
                    { new Guid("733d2eda-9c0f-11ee-8c90-0242ac120002"), "Home and Garden" },
                    { new Guid("780fcde6-9c0f-11ee-8c90-0242ac120002"), "Beauty and Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "email", "hashedpassword", "pass_salt", "phonenumber", "profileimage", "username", "usertype" },
                values: new object[] { new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"), "test@gmail.com", "", "", 123456789, "profile.jpg", "testuser", "user" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("3ac2239f-3d70-4da0-b81e-bda272847e7c"), new Guid("733d2eda-9c0f-11ee-8c90-0242ac120002"), "Kitchen and Appliances" },
                    { new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), new Guid("780fcde6-9c0f-11ee-8c90-0242ac120002"), "Face and Hair" },
                    { new Guid("92c17ce6-92b8-4515-9fc3-e38fcc51d83e"), new Guid("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), "Mobiles and Accesories" },
                    { new Guid("bb2dc742-a510-4a83-a0fa-e454df3a559c"), new Guid("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), "Tablets" },
                    { new Guid("ec5e2a09-3785-4b4b-90e6-1353ddb5aee6"), new Guid("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), "Computer Hardware" },
                    { new Guid("ef39fd90-d4fd-46aa-95bf-23672f549756"), new Guid("6d8e2cc8-9c0f-11ee-8c90-0242ac120002"), "Vegetables" },
                    { new Guid("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), new Guid("5cd3afb6-9c0f-11ee-8c90-0242ac120002"), "Video Games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedOn", "Barcode", "Description", "Images", "Name", "Price", "Quantity", "Sells", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("45ee830f-a1f3-44ad-8112-982ef324dab4"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Hair Care Kit", 200, 1, 0, new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199") },
                    { new Guid("4679e631-8273-49cd-91a6-fae714ea9d73"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Videogame", 500, 1, 0, new Guid("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e") },
                    { new Guid("4eaf8297-449c-4aea-a656-a92b8730a201"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "PC Build 2024", 500, 1, 0, new Guid("ec5e2a09-3785-4b4b-90e6-1353ddb5aee6") },
                    { new Guid("4fe905ac-63ae-4e9c-a10f-b6379b594c18"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Face Cosmetic Kit", 74, 1, 0, new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199") },
                    { new Guid("710df7a2-9cf9-4b80-89d5-20be76a621af"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Body Care Kit", 1000, 1, 0, new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199") },
                    { new Guid("b199f9b1-cf03-4990-876e-492df1cf69d1"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Playstation 5", 500, 1, 0, new Guid("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e") },
                    { new Guid("f4411dd9-d96a-4104-9d33-30f7beb3ad05"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Air Fryer", 500, 1, 0, new Guid("3ac2239f-3d70-4da0-b81e-bda272847e7c") },
                    { new Guid("f741ceca-8eed-40a6-8706-3181886a2e23"), new DateOnly(1, 1, 1), 0, "Description Test", "[\"1.jpg\",\"2.jpg\"]", "Android Tablet", 500, 1, 0, new Guid("92c17ce6-92b8-4515-9fc3-e38fcc51d83e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountEventProduct_ProductsId",
                table: "DiscountEventProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseLog_PurchaseLogsId",
                table: "ProductPurchaseLog",
                column: "PurchaseLogsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_UserId",
                table: "PurchaseLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountEventProduct");

            migrationBuilder.DropTable(
                name: "ProductPurchaseLog");

            migrationBuilder.DropTable(
                name: "DiscountEvents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseLogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParentCategories");
        }
    }
}
