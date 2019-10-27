using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.Context.Migrations
{
    public partial class AddFlagColumnToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlagImage",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagImage",
                table: "Teams");
        }
    }
}
