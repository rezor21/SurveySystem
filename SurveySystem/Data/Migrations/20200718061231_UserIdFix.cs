using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveySystem.Data.Migrations
{
    public partial class UserIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_AspNetUsers_UserId1",
                table: "UsersAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UsersAnswers_UserId1",
                table: "UsersAnswers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersAnswers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAnswers_UserId",
                table: "UsersAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_AspNetUsers_UserId",
                table: "UsersAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_AspNetUsers_UserId",
                table: "UsersAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UsersAnswers_UserId",
                table: "UsersAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UsersAnswers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAnswers_UserId1",
                table: "UsersAnswers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_AspNetUsers_UserId1",
                table: "UsersAnswers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
