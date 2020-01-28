using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f409c57c-cf3e-4f84-8765-d2240c2f26fc", "AQAAAAEAACcQAAAAEB5Ps7G89jKp7aRyJk2pHJZGyT8MW/8K4HA0o5U2aEiDOhdbb445tHMHH2EXwiAlCA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "848b96af-a386-4c74-a7c2-39fc0a08ac1e", "AQAAAAEAACcQAAAAEEGEDQQwUZQv0TlZ2Rrobs0P+I1JDnmdOumpvI8cuGz11weO6T/vTTYS0pgYB1N7Ig==" });
        }
    }
}
