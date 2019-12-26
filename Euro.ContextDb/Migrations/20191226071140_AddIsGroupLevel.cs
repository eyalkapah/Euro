using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.ContextDb.Migrations
{
    public partial class AddIsGroupLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGroupLevel",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 3,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 4,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 5,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 6,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 7,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 8,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 9,
                column: "IsGroupLevel",
                value: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 10,
                column: "IsGroupLevel",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGroupLevel",
                table: "Groups");
        }
    }
}
