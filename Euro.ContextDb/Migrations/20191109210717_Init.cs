using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.ContextDb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Groups");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlagImage = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    GuestScored = table.Column<int>(nullable: false),
                    GuestTeamId = table.Column<int>(nullable: false),
                    HostScored = table.Column<int>(nullable: false),
                    HostTeamId = table.Column<int>(nullable: false),
                    PlayDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_GuestTeamId",
                        column: x => x.GuestTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HostTeamId",
                        column: x => x.HostTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                    { 6, "F" },
                    { 7, "G" },
                    { 8, "H" },
                    { 9, "I" },
                    { 10, "J" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "FlagImage", "GroupId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "England" },
                    { 18, null, 7, "Israel" },
                    { 19, null, 7, "Slovenia" },
                    { 20, null, 7, "North Macedonia" },
                    { 21, null, 7, "Latvia" },
                    { 22, null, 7, "Austria" },
                    { 23, null, 7, "Poland" },
                    { 30, null, 8, "Moldova" },
                    { 31, null, 8, "France" },
                    { 32, null, 8, "Andora" },
                    { 33, null, 8, "Iceland" },
                    { 45, null, 6, "Norway" },
                    { 34, null, 8, "Albania" },
                    { 6, null, 9, "Kazakhstan" },
                    { 7, null, 9, "Scotland" },
                    { 8, null, 9, "Cyprus" },
                    { 9, null, 9, "San Marino" },
                    { 24, null, 9, "Belgium" },
                    { 25, null, 9, "Russia" },
                    { 46, null, 10, "Liechtenstein" },
                    { 47, null, 10, "Greece" },
                    { 48, null, 10, "Italy" },
                    { 49, null, 10, "Fineland" },
                    { 35, null, 8, "Turkey" },
                    { 50, null, 10, "Bosnia and Herzegovina" },
                    { 44, null, 6, "Spain" },
                    { 42, null, 6, "Malta" },
                    { 2, null, 1, "Chech Republic" },
                    { 3, null, 1, "Bulgaria" },
                    { 4, null, 1, "Montenegro" },
                    { 5, null, 1, "Kosovo" },
                    { 26, null, 2, "Portugal" },
                    { 27, null, 2, "Ukraine" },
                    { 28, null, 2, "Luxembourg" },
                    { 29, null, 2, "Lithuania" },
                    { 10, null, 3, "Northern Ireland" },
                    { 11, null, 3, "Estonia" },
                    { 43, null, 6, "Faroe Islands" },
                    { 12, null, 3, "Netherlands" },
                    { 36, null, 4, "Georgia" },
                    { 37, null, 4, "Switzerland" },
                    { 38, null, 4, "Gibraltar" },
                    { 39, null, 4, "Republic of Ireland" },
                    { 14, null, 5, "Slovkia" },
                    { 15, null, 5, "Hungary" },
                    { 16, null, 5, "Croatia" },
                    { 17, null, 5, "Azerbaijan" },
                    { 40, null, 6, "Sweden" },
                    { 41, null, 6, "Romania" },
                    { 13, null, 3, "Belarus" },
                    { 51, null, 10, "Armenia" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "GroupId", "GuestScored", "GuestTeamId", "HostScored", "HostTeamId", "PlayDateTime" },
                values: new object[,]
                {
                    { 3, 3, 0, 11, 2, 10, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 0, 13, 4, 12, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 0, 15, 2, 14, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, 1, 17, 2, 16, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 1, 19, 1, 18, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 7, 1, 21, 3, 20, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, 1, 23, 0, 22, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 9, 0, 7, 3, 6, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 9, 0, 9, 5, 8, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 9, 1, 25, 3, 24, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GroupId",
                table: "Matches",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GuestTeamId",
                table: "Matches",
                column: "GuestTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HostTeamId",
                table: "Matches",
                column: "HostTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GroupId",
                table: "Teams",
                column: "GroupId");
        }
    }
}