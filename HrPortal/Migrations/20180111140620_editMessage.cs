using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HrPortal.Migrations
{
    public partial class editMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_CompanyId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Resumes_ResumeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ApplicationUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CompanyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ResumeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromCompanyId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromResumeId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCompanyId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToResumeId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromCompanyId",
                table: "Messages",
                column: "FromCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromResumeId",
                table: "Messages",
                column: "FromResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToCompanyId",
                table: "Messages",
                column: "ToCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToResumeId",
                table: "Messages",
                column: "ToResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_FromCompanyId",
                table: "Messages",
                column: "FromCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Resumes_FromResumeId",
                table: "Messages",
                column: "FromResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_ToCompanyId",
                table: "Messages",
                column: "ToCompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Resumes_ToResumeId",
                table: "Messages",
                column: "ToResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_FromCompanyId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Resumes_FromResumeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_ToCompanyId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Resumes_ToResumeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromCompanyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromResumeId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToCompanyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ToResumeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromCompanyId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FromResumeId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SendDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToCompanyId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToResumeId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResumeId",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ApplicationUserId",
                table: "Messages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CompanyId",
                table: "Messages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ResumeId",
                table: "Messages",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ApplicationUserId",
                table: "Messages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_CompanyId",
                table: "Messages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Resumes_ResumeId",
                table: "Messages",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
