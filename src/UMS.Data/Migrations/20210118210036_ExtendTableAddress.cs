﻿namespace UMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ExtendTableAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Continent",
                table: "TeacherAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "TeacherAddress",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "TeacherAddress",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Continent",
                table: "StudentAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "StudentAddress",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "StudentAddress",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Continent",
                table: "FacultyAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "FacultyAddresses",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "FacultyAddresses",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Continent",
                table: "TeacherAddress");

            migrationBuilder.DropColumn(
                name: "District",
                table: "TeacherAddress");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "TeacherAddress");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "StudentAddress");

            migrationBuilder.DropColumn(
                name: "District",
                table: "StudentAddress");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "StudentAddress");

            migrationBuilder.DropColumn(
                name: "Continent",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "District",
                table: "FacultyAddresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "FacultyAddresses");
        }
    }
}
