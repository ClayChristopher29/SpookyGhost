using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class newyoutube : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "435af61a-0a5c-40dd-8c91-d93af3b465c7", "AQAAAAEAACcQAAAAEEOaIK6PPlxRU17UeDz/39Qpzl74yoefx+HOtFU6rF4TQ5Zk1de9gHHOzGBbjDKmaQ==" });

            migrationBuilder.UpdateData(
                table: "Evidence",
                keyColumn: "Id",
                keyValue: 2,
                column: "MyVideo",
                value: "https://youtu.be/vh99uSI22BU");
        }
    }
}
