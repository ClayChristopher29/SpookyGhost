using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghost.Data.Migrations
{
    public partial class buildDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NewUserName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: false),
                    PhNumber = table.Column<string>(nullable: true),
                    Hours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    Summary = table.Column<string>(nullable: false),
                    isPrivate = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investigation_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Investigation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    Summary = table.Column<string>(nullable: false),
                    MyAudio = table.Column<string>(nullable: true),
                    MyVideo = table.Column<string>(nullable: true),
                    InvestigationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidence_Investigation_InvestigationId",
                        column: x => x.InvestigationId,
                        principalTable: "Investigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evidence_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NewUserName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0000222211-22221111", 0, "92a04d8c-4f6b-4618-9ee1-40824694e930", "Ryan@Ryan.com", true, "Ryan", "Clay", false, null, "Ghost_Ryan", "RYAN@RYAN.COM", null, "AQAAAAEAACcQAAAAEGNjSU2bgHfP9e1zQ5kTwMGb07ClnnliOYDYFYnWUtuqKX9g79QYUVlVFlpqGF6wTA==", null, false, "12345-6789-ffffff", false, null });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Hours", "Name", "PhNumber", "Summary" },
                values: new object[,]
                {
                    { 1, "Monday-Friday 9:00am-5:00pm", "Trans-Allegheny Lunatic Asylum", "304-269-5070", "The Trans-Allegheny Lunatic Asylum, subsequently the Weston State Hospital, was a Kirkbride [3] psychiatric hospital that was operated from 1864 until 1994 by the government of the U.S. state of West Virginia, in the city of Weston. Weston State Hospital got its name in 1913 which was used while patients occupied it, but was changed back to its originally commissioned, unused name, the Trans-Allegheny Lunatic Asylum, after being reopened as a tourist attraction.http://www.trans-alleghenylunaticasylum.com/" },
                    { 2, "Monday-Friday, 9 am-4 pm. Closed for lunch 12p – 1p.", "West Virginia Penitentiary", "304-845-6200", "The West Virginia Penitentiary is a gothic-style prison located in Moundsville, West Virginia. Now withdrawn and retired from prison use, it operated from 1876 to 1995. Currently, the site is maintained as a tourist attraction and training facility.https://wvpentours.com/contact/" },
                    { 3, "Gates open from 5:00 PM. till 7:00 PM. FOR DAY PHOTOS ONLY,Gates open again at 7:00 PM.till 11:00 PM.Ticket Booth opens from 5:00 PM.till 10:30 PM.Photo History Tour & Lake Nightmare Hostel start at DUSK.", "Lake Shawnee Abandoned Amusment Park", "304-921-1580", "The Lake Shawnee Amusement Park is a defunct amusement park in Princeton, West Virginia, United States, located along Lake Shawnee. Opened in 1926, the park operated for 40 years before closing in 1966. It received public attention for a total of 6 deaths that occurred on the premises during its operations, which led to urban legends regarding the park being haunted. Due to these local legends,the park was featured on the television series Scariest Places on Earth in 2002" },
                    { 4, "Thursda-Saturday by appointment only", "Old Hospital on College Hill", "304-235-5240", "The Old Hospital On College Hill is a combination of paranormal tours and a haunted house that is open seasonally during the month of October in Williamson, West Virginia. The facility is only open Thursdays, Fridays, and Saturdays throughout October." }
                });

            migrationBuilder.InsertData(
                table: "Investigation",
                columns: new[] { "Id", "ApplicationUserId", "LocationId", "Summary", "isPrivate" },
                values: new object[] { 1, null, 1, "Investigation Number 1", true });

            migrationBuilder.InsertData(
                table: "Investigation",
                columns: new[] { "Id", "ApplicationUserId", "LocationId", "Summary", "isPrivate" },
                values: new object[] { 2, null, 2, "Investigation Number 2", false });

            migrationBuilder.InsertData(
                table: "Investigation",
                columns: new[] { "Id", "ApplicationUserId", "LocationId", "Summary", "isPrivate" },
                values: new object[] { 3, null, 3, "Investigation Number 3", true });

            migrationBuilder.InsertData(
                table: "Investigation",
                columns: new[] { "Id", "ApplicationUserId", "LocationId", "Summary", "isPrivate" },
                values: new object[] { 4, null, 4, "Investigation Number 4", false });

            migrationBuilder.InsertData(
                table: "Evidence",
                columns: new[] { "Id", "InvestigationId", "MyAudio", "MyVideo", "Summary", "Type", "UserId" },
                values: new object[] { 1, 1, "https://townsquare.media/site/518/files/2013/01/5-026StitchinTimeSavesNine.mp3", null, "Spooky Ghost was heard here", "Audio", "0000222211-22221111" });

            migrationBuilder.InsertData(
                table: "Evidence",
                columns: new[] { "Id", "InvestigationId", "MyAudio", "MyVideo", "Summary", "Type", "UserId" },
                values: new object[] { 2, 2, null, "https://youtu.be/vh99uSI22BU", "Spooky Ghost was seen here", "Video", "0000222211-22221111" });

            migrationBuilder.InsertData(
                table: "Evidence",
                columns: new[] { "Id", "InvestigationId", "MyAudio", "MyVideo", "Summary", "Type", "UserId" },
                values: new object[] { 3, 2, null, "https://youtu.be/nFqpo0zcvow", "Spooky Ghost was seen here", "Video", "0000222211-22221111" });

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_InvestigationId",
                table: "Evidence",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_UserId",
                table: "Evidence",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigation_ApplicationUserId",
                table: "Investigation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Investigation_LocationId",
                table: "Investigation",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "Investigation");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0000222211-22221111");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NewUserName",
                table: "AspNetUsers");
        }
    }
}
