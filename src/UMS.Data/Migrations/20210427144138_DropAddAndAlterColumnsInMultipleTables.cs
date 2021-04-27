namespace UMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DropAddAndAlterColumnsInMultipleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_AspNetUsers_ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddedByUserId",
                table: "Resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddedByUserId",
                table: "Homeworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AddedByUserId",
                table: "Resources",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_AddedByUserId",
                table: "Homeworks",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_AspNetUsers_AddedByUserId",
                table: "Homeworks",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_AddedByUserId",
                table: "Resources",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_AspNetUsers_AddedByUserId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_AddedByUserId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AddedByUserId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_AddedByUserId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Homeworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_ApplicationUserId",
                table: "Homeworks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_AspNetUsers_ApplicationUserId",
                table: "Homeworks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
