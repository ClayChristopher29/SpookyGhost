using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class newuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "898dd8b6-4143-4aa3-bf2d-a7c4e2092576", "AQAAAAEAACcQAAAAEAfYHvW/Ovc2mPHG0QcLoG8xM20v5CfkCDa3xA6cNZGVFxaZYzm35C7l8ldSgig46w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b59ce74f-9e18-4558-be59-6c497b832bb0", "AQAAAAEAACcQAAAAEK7FITFVcj5BoH2kx639BcTAHh4ZDH+nxX8U10GY3zj5nEX8y47xOYDSNLQ6zRMJFQ==" });
        }
    }
}
