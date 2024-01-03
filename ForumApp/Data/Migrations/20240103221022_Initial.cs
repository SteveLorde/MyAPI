using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    pass_salt = table.Column<string>(type: "TEXT", nullable: false),
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
