using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Data.Migrations
{
    public partial class UpdateCompanyClaimsCompanyIdColumnNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims");

            migrationBuilder.DropIndex(
                name: "IX_CompanyClaims_ComapnayId",
                table: "CompanyClaims");

            migrationBuilder.DropColumn(
                name: "ComapnayId",
                table: "CompanyClaims");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_CompanyId",
                table: "CompanyClaims",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_Companies_CompanyId",
                table: "CompanyClaims",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_Companies_CompanyId",
                table: "CompanyClaims");

            migrationBuilder.DropIndex(
                name: "IX_CompanyClaims_CompanyId",
                table: "CompanyClaims");

            migrationBuilder.AddColumn<int>(
                name: "ComapnayId",
                table: "CompanyClaims",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClaims_ComapnayId",
                table: "CompanyClaims",
                column: "ComapnayId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims",
                column: "ComapnayId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
