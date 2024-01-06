using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAPI.ForumApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forumapp_categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forumapp_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "forumapp_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    hashedpassword = table.Column<string>(type: "TEXT", nullable: false),
                    usertype = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    profileimage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forumapp_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "forumapp_subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forumapp_subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forumapp_subcategories_forumapp_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "forumapp_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forumapp_threads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    numofposts = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forumapp_threads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forumapp_threads_forumapp_subcategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "forumapp_subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forumapp_threads_forumapp_users_UserId",
                        column: x => x.UserId,
                        principalTable: "forumapp_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forumapp_posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    body = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ThreadId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forumapp_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forumapp_posts_forumapp_threads_ThreadId",
                        column: x => x.ThreadId,
                        principalTable: "forumapp_threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forumapp_posts_forumapp_users_UserId",
                        column: x => x.UserId,
                        principalTable: "forumapp_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "forumapp_categories",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { new Guid("833dbbe8-b226-4b88-bd2b-9638f9e782d6"), "Category 3" },
                    { new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"), "Category 1" },
                    { new Guid("c2515af9-2d60-4239-a774-551cecf0b836"), "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "forumapp_users",
                columns: new[] { "Id", "date", "email", "hashedpassword", "profileimage", "username", "usertype" },
                values: new object[,]
                {
                    { new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), new DateTime(2024, 1, 6, 18, 6, 50, 777, DateTimeKind.Local).AddTicks(2634), "testuser2@gmail.com", "5TVQCRVtmFZd2a7QwudJ8Q==.26ruMzrzGBEslRZz/v1Gim+s05PREAXQTSjOGlxRbwA=", "", "testuser2", "user" },
                    { new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), new DateTime(2024, 1, 6, 18, 6, 50, 777, DateTimeKind.Local).AddTicks(2573), "testuser1@gmail.com", "poxUxQqLwQsX+2xqtRiEvw==.+qLJTa0B+zPSxMUNhVVPTmbu59i0iARQt7vlvcYTCss=", "", "testuser1", "user" }
                });

            migrationBuilder.InsertData(
                table: "forumapp_subcategories",
                columns: new[] { "Id", "CategoryId", "name" },
                values: new object[,]
                {
                    { new Guid("10805305-586a-4301-8289-d054bdce87c8"), new Guid("c2515af9-2d60-4239-a774-551cecf0b836"), "subcategory4" },
                    { new Guid("6642cc50-1728-40fc-8656-245166023209"), new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"), "subcategory3" },
                    { new Guid("a522cea4-f16c-47e3-acaf-62c0161b0922"), new Guid("833dbbe8-b226-4b88-bd2b-9638f9e782d6"), "subcategory6" },
                    { new Guid("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3"), new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"), "subcategory1" },
                    { new Guid("d32bda2e-7b46-4aa8-b1aa-5afcdea98f69"), new Guid("c2515af9-2d60-4239-a774-551cecf0b836"), "subcategory5" },
                    { new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"), new Guid("90c4cfc8-45a4-4161-8c74-732f65a84f89"), "subcategory2" }
                });

            migrationBuilder.InsertData(
                table: "forumapp_threads",
                columns: new[] { "Id", "SubCategoryId", "UserId", "date", "numofposts", "title" },
                values: new object[,]
                {
                    { new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"), new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), 2, "thread 1" },
                    { new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"), new Guid("e008fb3e-bf09-4918-8f53-8e71a1a8d0e6"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), 2, "thread 1" },
                    { new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"), new Guid("cefe05d1-5747-4bfc-acb2-8f0d0cadcaf3"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local), 2, "thread 1" }
                });

            migrationBuilder.InsertData(
                table: "forumapp_posts",
                columns: new[] { "Id", "ThreadId", "UserId", "body", "date" },
                values: new object[,]
                {
                    { new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"), new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"), new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("272f7784-81ed-4961-b811-afcd1e349caf"), new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"), new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"), new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"), new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"), new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("582fb677-681f-46db-8327-5c25e835845f"), new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("862042a9-b136-4153-a63b-1518ccfc5411"), new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"), new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"), new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"), new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"), "Test Post", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_forumapp_posts_ThreadId",
                table: "forumapp_posts",
                column: "ThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_forumapp_posts_UserId",
                table: "forumapp_posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_forumapp_subcategories_CategoryId",
                table: "forumapp_subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_forumapp_threads_SubCategoryId",
                table: "forumapp_threads",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_forumapp_threads_UserId",
                table: "forumapp_threads",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forumapp_posts");

            migrationBuilder.DropTable(
                name: "forumapp_threads");

            migrationBuilder.DropTable(
                name: "forumapp_subcategories");

            migrationBuilder.DropTable(
                name: "forumapp_users");

            migrationBuilder.DropTable(
                name: "forumapp_categories");
        }
    }
}
