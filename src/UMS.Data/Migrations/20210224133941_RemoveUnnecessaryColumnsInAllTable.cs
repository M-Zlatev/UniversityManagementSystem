namespace UMS.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveUnnecessaryColumnsInAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeacherAddresses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TeacherAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "StudentAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Faculties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Faculties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IsDeleted",
                table: "Teachers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IsDeleted",
                table: "Students",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_IsDeleted",
                table: "Majors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_IsDeleted",
                table: "Faculties",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_IsDeleted",
                table: "Departments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_IsDeleted",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_IsDeleted",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Majors_IsDeleted",
                table: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_IsDeleted",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Departments_IsDeleted",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeacherAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TeacherAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "StudentAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Resources",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Resources",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Majors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Homeworks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Homeworks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FacultyAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FacultyAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FacultyAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FacultyAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
