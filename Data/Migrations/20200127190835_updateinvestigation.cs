using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class updateinvestigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigation_AspNetUsers_ApplicationUserId",
                table: "Investigation");

            migrationBuilder.DropIndex(
                name: "IX_Investigation_ApplicationUserId",
                table: "Investigation");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Investigation");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Investigation",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "848b96af-a386-4c74-a7c2-39fc0a08ac1e", "AQAAAAEAACcQAAAAEEGEDQQwUZQv0TlZ2Rrobs0P+I1JDnmdOumpvI8cuGz11weO6T/vTTYS0pgYB1N7Ig==" });

            migrationBuilder.CreateIndex(
                name: "IX_Investigation_UserId",
                table: "Investigation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigation_AspNetUsers_UserId",
                table: "Investigation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investigation_AspNetUsers_UserId",
                table: "Investigation");

            migrationBuilder.DropIndex(
                name: "IX_Investigation_UserId",
                table: "Investigation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Investigation");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Investigation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92a04d8c-4f6b-4618-9ee1-40824694e930", "AQAAAAEAACcQAAAAEGNjSU2bgHfP9e1zQ5kTwMGb07ClnnliOYDYFYnWUtuqKX9g79QYUVlVFlpqGF6wTA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Investigation_ApplicationUserId",
                table: "Investigation",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investigation_AspNetUsers_ApplicationUserId",
                table: "Investigation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
