using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class addednameInvest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Investigation",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Investigation",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "435af61a-0a5c-40dd-8c91-d93af3b465c7", "AQAAAAEAACcQAAAAEEOaIK6PPlxRU17UeDz/39Qpzl74yoefx+HOtFU6rF4TQ5Zk1de9gHHOzGBbjDKmaQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Investigation");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Investigation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc193d8a-b914-4bd6-aafa-d9a3f3e71e20", "AQAAAAEAACcQAAAAEDnUVKL0PPPB5DKobiq9m1JgDdYWasatNNfbbWXKR3SK8AZyldcKSHtCmdrtUe60ag==" });
        }
    }
}
