using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.ForumApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class namingconventionedits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "forumapp_posts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "forumapp_posts",
                newName: "Body");

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("272f7784-81ed-4961-b811-afcd1e349caf"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("582fb677-681f-46db-8327-5c25e835845f"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("862042a9-b136-4153-a63b-1518ccfc5411"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"),
                column: "Date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                column: "date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                column: "date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                column: "date",
                value: new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("cb89bdb8-348a-4af4-b837-8caa71bd7fb0"),
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 2, 17, 19, 7, 29, 410, DateTimeKind.Local).AddTicks(9889), "+IjVOs/eCNryLhzweaRq+w==.5jDMzF2ZPGjJ2OqL34+Mn3419oWGEW1f0pYFboo4GMM=" });

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                columns: new[] { "date", "hashedpassword", "profileimage" },
                values: new object[] { new DateTime(2024, 2, 17, 19, 7, 29, 410, DateTimeKind.Local).AddTicks(9824), "pTuiN8jBDpsB4ZAPqIYdEA==.oAsVdvdXY07lwychdUdqYd/iXaINc5p2HOpAAmAMcBg=", "profilepic.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "forumapp_posts",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "forumapp_posts",
                newName: "body");

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("138670af-28f1-4f35-8b3d-ea2f471e8aa1"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("272f7784-81ed-4961-b811-afcd1e349caf"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("31a43a68-1c17-44e0-9ca7-aa0226b68eee"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("4f59aba9-1628-4478-9657-c5ed7e46c38e"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("582fb677-681f-46db-8327-5c25e835845f"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("862042a9-b136-4153-a63b-1518ccfc5411"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "forumapp_posts",
                keyColumn: "Id",
                keyValue: new Guid("bd936dff-86e8-49bb-85ce-3ad6bea81428"),
                column: "date",
                value: new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

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
                values: new object[] { new DateTime(2024, 2, 4, 18, 0, 26, 23, DateTimeKind.Local).AddTicks(7066), "4gbxO8GXZHQPXPkSs+4I5g==.JHyZsmPEwQgk7rsF/4uhfDd3WKPwA35Siu5UhwNZIK8=" });

            migrationBuilder.UpdateData(
                table: "forumapp_users",
                keyColumn: "Id",
                keyValue: new Guid("f36d69a4-9c09-4c08-9da4-a315d2093385"),
                columns: new[] { "date", "hashedpassword", "profileimage" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 0, 26, 23, DateTimeKind.Local).AddTicks(6983), "TiaSS3yu07Yx2dZ+YvpjJw==.MoUHP/6P+U0MzO3YAJwFQx2bD2AySUdiyrUicBGBXz4=", "" });
        }
    }
}
