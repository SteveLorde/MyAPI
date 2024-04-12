using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.ForumApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedordernumberforposts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ordernum",
                table: "forumapp_posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("272f7784-81ed-4961-b811-afcd1e349caf"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("582fb677-681f-46db-8327-5c25e835845f"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("862042a9-b136-4153-a63b-1518ccfc5411"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"),
                columns: new[] { "date", "ordernum" },
                values: new object[] { new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 2, 4, 11, 4, 20, 566, DateTimeKind.Local).AddTicks(7248), "yPVGYTBCaC9HZDu40X62Xg==.5B6PvT5n1u+fblAr0i4yx6dOMa9Oz4/WhUOMaApGFQk=" });

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 2, 4, 11, 4, 20, 566, DateTimeKind.Local).AddTicks(7184), "t8Se3Bwb3HyAZnKSZUrR5g==.qAu6yEy7DnRcgsP3tmXJwRyyph7S1x6yZyKRv59C6WU=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ordernum",
                table: "forumapp_posts");

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("272f7784-81ed-4961-b811-afcd1e349caf"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("582fb677-681f-46db-8327-5c25e835845f"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("862042a9-b136-4153-a63b-1518ccfc5411"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                column: "date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 41, 46, 155, DateTimeKind.Local).AddTicks(8084), "5gNo1HxL3K2wYom1YchxmQ==.+R5V3wwutk8ggt8WeZL3TNgwX4Flq8Fq7eoW1BB83zk=" });

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 41, 46, 155, DateTimeKind.Local).AddTicks(7931), "DOQxmilHnXarEHYXaaiXQg==.ODzqtIkcvQSSrwwhe66nH14eKH4vNTX26MSAJS/Zpg4=" });
        }
    }
}
