using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class changerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyMember");

            migrationBuilder.AddColumn<int>(
                name: "HobbyId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_HobbyId",
                table: "Members",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Hobbies_HobbyId",
                table: "Members",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Hobbies_HobbyId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_HobbyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "HobbyId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "HobbyMember",
                columns: table => new
                {
                    HobbiesId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyMember", x => new { x.HobbiesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_HobbyMember_Hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyMember_MembersId",
                table: "HobbyMember",
                column: "MembersId");
        }
    }
}
