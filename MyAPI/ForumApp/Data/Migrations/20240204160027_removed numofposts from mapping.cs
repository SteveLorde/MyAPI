using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAPI.ForumApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class removednumofpostsfrommapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numofposts",
                table: "forumapp_threads");

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
                columns: new[] { "date", "hashedpassword" },
                values: new object[] { new DateTime(2024, 2, 4, 18, 0, 26, 23, DateTimeKind.Local).AddTicks(6983), "TiaSS3yu07Yx2dZ+YvpjJw==.MoUHP/6P+U0MzO3YAJwFQx2bD2AySUdiyrUicBGBXz4=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numofposts",
                table: "forumapp_threads",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("25fc63f8-9b86-48c2-a75d-40c4f357c1e7"),
                column: "numofposts",
                value: 2);

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("8e51677c-37bb-4658-90a5-45a00bf79880"),
                column: "numofposts",
                value: 2);

            migrationBuilder.UpdateData(
                table: "forumapp_threads",
                keyColumn: "Id",
                keyValue: new Guid("d9374b25-64b3-4901-ad55-8a47d3e54275"),
                column: "numofposts",
                value: 2);

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
    }
}
