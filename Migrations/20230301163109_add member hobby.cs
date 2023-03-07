using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class addmemberhobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Members_MemberId",
                table: "Hobbies");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Hobbies",
                newName: "MemberHobbyId");

            migrationBuilder.RenameIndex(
                name: "IX_Hobbies_MemberId",
                table: "Hobbies",
                newName: "IX_Hobbies_MemberHobbyId");

            migrationBuilder.AddColumn<int>(
                name: "MemberHobbyId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembersHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersHobbies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberHobbyId",
                table: "Members",
                column: "MemberHobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_MembersHobbies_MemberHobbyId",
                table: "Hobbies",
                column: "MemberHobbyId",
                principalTable: "MembersHobbies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MembersHobbies_MemberHobbyId",
                table: "Members",
                column: "MemberHobbyId",
                principalTable: "MembersHobbies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_MembersHobbies_MemberHobbyId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MembersHobbies_MemberHobbyId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "MembersHobbies");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberHobbyId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberHobbyId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "MemberHobbyId",
                table: "Hobbies",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Hobbies_MemberHobbyId",
                table: "Hobbies",
                newName: "IX_Hobbies_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Members_MemberId",
                table: "Hobbies",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
