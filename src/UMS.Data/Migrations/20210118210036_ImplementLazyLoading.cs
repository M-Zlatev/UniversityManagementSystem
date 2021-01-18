namespace UMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ImplementLazyLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMajor_Courses_CourseId",
                table: "CourseMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMajor_Majors_MajorId",
                table: "CourseMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajor_Majors_MajorId",
                table: "StudentMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajor_Students_StudentId",
                table: "StudentMajor");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMajor",
                table: "StudentMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMajor",
                table: "CourseMajor");

            migrationBuilder.RenameTable(
                name: "StudentMajor",
                newName: "StudentMajors");

            migrationBuilder.RenameTable(
                name: "CourseMajor",
                newName: "CourseMajors");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMajor_MajorId",
                table: "StudentMajors",
                newName: "IX_StudentMajors_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMajor_MajorId",
                table: "CourseMajors",
                newName: "IX_CourseMajors_MajorId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMajors",
                table: "StudentMajors",
                columns: new[] { "StudentId", "MajorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMajors",
                table: "CourseMajors",
                columns: new[] { "CourseId", "MajorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMajors_Courses_CourseId",
                table: "CourseMajors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMajors_Majors_MajorId",
                table: "CourseMajors",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajors_Majors_MajorId",
                table: "StudentMajors",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajors_Students_StudentId",
                table: "StudentMajors",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMajors_Courses_CourseId",
                table: "CourseMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMajors_Majors_MajorId",
                table: "CourseMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajors_Majors_MajorId",
                table: "StudentMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMajors_Students_StudentId",
                table: "StudentMajors");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentMajors",
                table: "StudentMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMajors",
                table: "CourseMajors");

            migrationBuilder.RenameTable(
                name: "StudentMajors",
                newName: "StudentMajor");

            migrationBuilder.RenameTable(
                name: "CourseMajors",
                newName: "CourseMajor");

            migrationBuilder.RenameIndex(
                name: "IX_StudentMajors_MajorId",
                table: "StudentMajor",
                newName: "IX_StudentMajor_MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMajors_MajorId",
                table: "CourseMajor",
                newName: "IX_CourseMajor_MajorId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Addresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentMajor",
                table: "StudentMajor",
                columns: new[] { "StudentId", "MajorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMajor",
                table: "CourseMajor",
                columns: new[] { "CourseId", "MajorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMajor_Courses_CourseId",
                table: "CourseMajor",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMajor_Majors_MajorId",
                table: "CourseMajor",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajor_Majors_MajorId",
                table: "StudentMajor",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentMajor_Students_StudentId",
                table: "StudentMajor",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
