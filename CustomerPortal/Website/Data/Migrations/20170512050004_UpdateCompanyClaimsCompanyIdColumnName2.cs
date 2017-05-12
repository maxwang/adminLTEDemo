using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Data.Migrations
{
    public partial class UpdateCompanyClaimsCompanyIdColumnName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUsers_Companies_ComapnayId",
                table: "CompanyUsers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyUsers_ComapnayId",
                table: "CompanyUsers");

            migrationBuilder.DropColumn(
                name: "ComapnayId",
                table: "CompanyUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUsers_Companies_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUsers_Companies_CompanyId",
                table: "CompanyUsers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers");

            migrationBuilder.AddColumn<int>(
                name: "ComapnayId",
                table: "CompanyUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_ComapnayId",
                table: "CompanyUsers",
                column: "ComapnayId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUsers_Companies_ComapnayId",
                table: "CompanyUsers",
                column: "ComapnayId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
