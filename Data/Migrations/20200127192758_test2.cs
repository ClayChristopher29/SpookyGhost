using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc193d8a-b914-4bd6-aafa-d9a3f3e71e20", "AQAAAAEAACcQAAAAEDnUVKL0PPPB5DKobiq9m1JgDdYWasatNNfbbWXKR3SK8AZyldcKSHtCmdrtUe60ag==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f409c57c-cf3e-4f84-8765-d2240c2f26fc", "AQAAAAEAACcQAAAAEB5Ps7G89jKp7aRyJk2pHJZGyT8MW/8K4HA0o5U2aEiDOhdbb445tHMHH2EXwiAlCA==" });
        }
    }
}
