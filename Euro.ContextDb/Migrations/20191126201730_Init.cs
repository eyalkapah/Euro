using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Euro.ContextDb.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
