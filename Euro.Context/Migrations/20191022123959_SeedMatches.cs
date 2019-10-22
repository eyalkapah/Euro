using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.Context.Migrations
{
    public partial class SeedMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "GuestScored", "GuestTeamId", "HostScored", "HostTeamId", "PlayDateTime", "TeamId" },
                values: new object[,]
                {
                    { 1, 0, 7, 3, 6, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 0, 9, 5, 8, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 0, 11, 2, 10, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 0, 13, 4, 12, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 0, 15, 2, 14, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 1, 17, 2, 16, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 1, 19, 1, 18, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 1, 21, 3, 20, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 1, 23, 0, 22, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 1, 25, 3, 24, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 10);
        }
    }
}
