using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class newyoutube2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f729743-8a64-4923-bcd3-5ce6c1771a14", "AQAAAAEAACcQAAAAEMkf7tvGpbf5HdwklAF2jFaSUXBCuauf+BDuKflsZSYtB0XoEfns+G2BDKPoW39O+Q==" });

            migrationBuilder.UpdateData(
                table: "Evidence",
                keyColumn: "Id",
                keyValue: 2,
                column: "MyVideo",
                value: "https://www.youtube.com/embed/otMctguGofg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b78b548b-77f3-4bad-b7a6-aa3cdcb01ad9", "AQAAAAEAACcQAAAAEPff9ruMXRe7aElp3fpbOxXQcRk1q4KG17ql5gODzPTSXNSTkg6yjvUDCxEb4rlMJQ==" });

            migrationBuilder.UpdateData(
                table: "Evidence",
                keyColumn: "Id",
                keyValue: 2,
                column: "MyVideo",
                value: "https://www.youtube.com/watch?v=otMctguGofg");
        }
    }
}
