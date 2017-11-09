using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HrPortal.Data.Migrations
{
    public partial class addOccupations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Occupation_OccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation");

            migrationBuilder.RenameTable(
                name: "Occupation",
                newName: "Occupations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupations",
                table: "Occupations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Occupations_OccupationId",
                table: "AspNetUsers",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Occupations_OccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Occupations",
                table: "Occupations");

            migrationBuilder.RenameTable(
                name: "Occupations",
                newName: "Occupation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occupation",
                table: "Occupation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Occupation_OccupationId",
                table: "AspNetUsers",
                column: "OccupationId",
                principalTable: "Occupation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
