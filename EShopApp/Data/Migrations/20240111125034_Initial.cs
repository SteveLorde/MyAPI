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
                    discountname = table.Column<string>(type: "TEXT", nullable: false),
                    discountamount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    subtitle = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    published = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
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
                    pass_salt = table.Column<string>(type: "TEXT", nullable: true),
                    hashedpassword = table.Column<string>(type: "TEXT", nullable: true),
                    usertype = table.Column<string>(type: "TEXT", nullable: false),
                    phonenumber = table.Column<int>(type: "INTEGER", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    profileimage = table.Column<string>(type: "TEXT", nullable: true)
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
                    ParentCategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    descriptionbullets = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    price = table.Column<int>(type: "INTEGER", nullable: true),
                    barcode = table.Column<int>(type: "INTEGER", nullable: true),
                    storequantity = table.Column<int>(type: "INTEGER", nullable: false),
                    addedon = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    DiscountEventId = table.Column<Guid>(type: "TEXT", nullable: true),
                    images = table.Column<string>(type: "TEXT", nullable: true),
                    sells = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_DiscountEvents_DiscountEventId",
                        column: x => x.DiscountEventId,
                        principalTable: "DiscountEvents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    accepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    datetime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscountEvent",
                columns: new[] { "Id", "description", "image", "published", "subtitle", "title" },
                values: new object[,]
                {
                    { new Guid("0d8b8ff5-db08-4ee0-ae55-dd0267116b5d"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Christmas Discounts on Electronics" },
                    { new Guid("1a55b12e-65b8-4542-b4c1-6676c30311e7"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Shop Smart, Save Big: Exclusive Year-End Sale with Unbeatable Discounts!" },
                    { new Guid("93097c20-6558-4ed9-a27e-8bf07fb59b8a"), "Desc Test", "newscover.jpg", new DateOnly(2024, 1, 1), null, "Digital Winter VideoGames Sales" }
                });

            migrationBuilder.InsertData(
                table: "ParentCategories",
                columns: new[] { "Id", "name" },
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
                values: new object[] { new Guid("c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"), "test@gmail.com", null, null, 123456789, "profile.jpg", "testuser", "user" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ParentCategoryId", "name" },
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
                columns: new[] { "Id", "CategoryId", "DiscountEventId", "addedon", "barcode", "description", "descriptionbullets", "images", "name", "price", "sells", "storequantity" },
                values: new object[,]
                {
                    { new Guid("45ee830f-a1f3-44ad-8112-982ef324dab4"), new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Hair Care Kit", 200, null, 0 },
                    { new Guid("4679e631-8273-49cd-91a6-fae714ea9d73"), new Guid("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Videogame", 500, null, 0 },
                    { new Guid("4eaf8297-449c-4aea-a656-a92b8730a201"), new Guid("ec5e2a09-3785-4b4b-90e6-1353ddb5aee6"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "PC Build 2024", 500, null, 0 },
                    { new Guid("4fe905ac-63ae-4e9c-a10f-b6379b594c18"), new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Face Cosmetic Kit", 74, null, 0 },
                    { new Guid("710df7a2-9cf9-4b80-89d5-20be76a621af"), new Guid("3e80f63e-6866-4a58-a7e7-8151b8c7c199"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Body Care Kit", 1000, null, 0 },
                    { new Guid("b199f9b1-cf03-4990-876e-492df1cf69d1"), new Guid("f1c3a402-5e08-4e13-a08f-4d9ab5062a9e"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Playstation 5", 500, null, 0 },
                    { new Guid("f4411dd9-d96a-4104-9d33-30f7beb3ad05"), new Guid("3ac2239f-3d70-4da0-b81e-bda272847e7c"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Air Fryer", 500, null, 0 },
                    { new Guid("f741ceca-8eed-40a6-8706-3181886a2e23"), new Guid("92c17ce6-92b8-4515-9fc3-e38fcc51d83e"), null, null, null, "Description Test", null, "[\"1.jpg\",\"2.jpg\"]", "Android Tablet", 500, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountEventId",
                table: "Products",
                column: "DiscountEventId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_ProductId",
                table: "PurchaseLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLogs_UserId",
                table: "PurchaseLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountEvent");

            migrationBuilder.DropTable(
                name: "PurchaseLogs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DiscountEvents");

            migrationBuilder.DropTable(
                name: "ParentCategories");
        }
    }
}
