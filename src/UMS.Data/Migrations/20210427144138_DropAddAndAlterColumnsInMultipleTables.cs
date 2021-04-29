namespace UMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DropAddAndAlterColumnsInMultipleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserAddress_AspNetUsers_UserId",
                table: "ApplicationUserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_AspNetUsers_UserId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourse_Courses_UserId",
                table: "ApplicationUserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMajor_AspNetUsers_UserId",
                table: "ApplicationUserMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMajor_Majors_UserId",
                table: "ApplicationUserMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_AspNetUsers_ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMajor",
                table: "ApplicationUserMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCourse",
                table: "ApplicationUserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserAddress",
                table: "ApplicationUserAddress");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Homeworks");

            migrationBuilder.RenameTable(
                name: "ApplicationUserMajor",
                newName: "ApplicationUserMajors");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCourse",
                newName: "ApplicationUserCourses");

            migrationBuilder.RenameTable(
                name: "ApplicationUserAddress",
                newName: "ApplicationUserAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserAddress_UserId",
                table: "ApplicationUserAddresses",
                newName: "IX_ApplicationUserAddresses_UserId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMajors",
                table: "ApplicationUserMajors",
                columns: new[] { "UserId", "MajorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCourses",
                table: "ApplicationUserCourses",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserAddresses",
                table: "ApplicationUserAddresses",
                column: "Id");

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
                name: "FK_ApplicationUserAddresses_AspNetUsers_UserId",
                table: "ApplicationUserAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourses_AspNetUsers_UserId",
                table: "ApplicationUserCourses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourses_Courses_UserId",
                table: "ApplicationUserCourses",
                column: "UserId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMajors_AspNetUsers_UserId",
                table: "ApplicationUserMajors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMajors_Majors_UserId",
                table: "ApplicationUserMajors",
                column: "UserId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ApplicationUserAddresses_AspNetUsers_UserId",
                table: "ApplicationUserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourses_AspNetUsers_UserId",
                table: "ApplicationUserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserCourses_Courses_UserId",
                table: "ApplicationUserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMajors_AspNetUsers_UserId",
                table: "ApplicationUserMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserMajors_Majors_UserId",
                table: "ApplicationUserMajors");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserMajors",
                table: "ApplicationUserMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserCourses",
                table: "ApplicationUserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserAddresses",
                table: "ApplicationUserAddresses");

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

            migrationBuilder.RenameTable(
                name: "ApplicationUserMajors",
                newName: "ApplicationUserMajor");

            migrationBuilder.RenameTable(
                name: "ApplicationUserCourses",
                newName: "ApplicationUserCourse");

            migrationBuilder.RenameTable(
                name: "ApplicationUserAddresses",
                newName: "ApplicationUserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserAddresses_UserId",
                table: "ApplicationUserAddress",
                newName: "IX_ApplicationUserAddress_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Homeworks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserMajor",
                table: "ApplicationUserMajor",
                columns: new[] { "UserId", "MajorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserCourse",
                table: "ApplicationUserCourse",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserAddress",
                table: "ApplicationUserAddress",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_ApplicationUserId",
                table: "Homeworks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserAddress_AspNetUsers_UserId",
                table: "ApplicationUserAddress",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_AspNetUsers_UserId",
                table: "ApplicationUserCourse",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserCourse_Courses_UserId",
                table: "ApplicationUserCourse",
                column: "UserId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMajor_AspNetUsers_UserId",
                table: "ApplicationUserMajor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserMajor_Majors_UserId",
                table: "ApplicationUserMajor",
                column: "UserId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
