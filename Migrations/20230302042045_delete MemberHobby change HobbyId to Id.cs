using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleAPI.Migrations
{
    public partial class deleteMemberHobbychangeHobbyIdtoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyMember_Hobbies_HobbiesHobbyId",
                table: "HobbyMember");

            migrationBuilder.DropTable(
                name: "MemberHobbies");

            migrationBuilder.RenameColumn(
                name: "HobbiesHobbyId",
                table: "HobbyMember",
                newName: "HobbiesId");

            migrationBuilder.RenameColumn(
                name: "HobbyId",
                table: "Hobbies",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyMember_Hobbies_HobbiesId",
                table: "HobbyMember",
                column: "HobbiesId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyMember_Hobbies_HobbiesId",
                table: "HobbyMember");

            migrationBuilder.RenameColumn(
                name: "HobbiesId",
                table: "HobbyMember",
                newName: "HobbiesHobbyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hobbies",
                newName: "HobbyId");

            migrationBuilder.CreateTable(
                name: "MemberHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbiyId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberHobbies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyMember_Hobbies_HobbiesHobbyId",
                table: "HobbyMember",
                column: "HobbiesHobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
