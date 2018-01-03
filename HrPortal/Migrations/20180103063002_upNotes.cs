using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HrPortal.Migrations
{
    public partial class upNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "EducationInfos");

            migrationBuilder.AddColumn<string>(
                name: "ResumeNotes",
                table: "Resumes",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceNotes",
                table: "Experiences",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationInfoNotes",
                table: "EducationInfos",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeNotes",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ExperienceNotes",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "EducationInfoNotes",
                table: "EducationInfos");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Resumes",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Experiences",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "EducationInfos",
                maxLength: 4000,
                nullable: true);
        }
    }
}
