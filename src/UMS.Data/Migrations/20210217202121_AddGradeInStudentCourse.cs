namespace UMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGradeInStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "StudentCourses",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentCourses");
        }
    }
}
