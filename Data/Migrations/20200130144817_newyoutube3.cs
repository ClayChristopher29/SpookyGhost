using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class newyoutube3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b59ce74f-9e18-4558-be59-6c497b832bb0", "AQAAAAEAACcQAAAAEK7FITFVcj5BoH2kx639BcTAHh4ZDH+nxX8U10GY3zj5nEX8y47xOYDSNLQ6zRMJFQ==" });

            migrationBuilder.UpdateData(
                table: "Evidence",
                keyColumn: "Id",
                keyValue: 3,
                column: "MyVideo",
                value: "https://www.youtube.com/embed/RTSN4eovN6A?list=PLDFTJm5CqjzeGOvfnFm6OzGv9upFR9D1n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 3,
                column: "MyVideo",
                value: "https://youtu.be/nFqpo0zcvow");
        }
    }
}
