using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.Context.Migrations
{
    public partial class SeedTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "GroupId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "England" },
                    { 2, 1, "Chech Republic" },
                    { 3, 1, "Bulgaria" },
                    { 4, 1, "Montenegro" },
                    { 5, 1, "Kosovo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5);
        }
    }
}
