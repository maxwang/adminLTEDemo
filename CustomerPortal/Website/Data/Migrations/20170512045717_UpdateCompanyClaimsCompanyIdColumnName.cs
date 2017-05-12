using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Data.Migrations
{
    public partial class UpdateCompanyClaimsCompanyIdColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims");

            migrationBuilder.AlterColumn<int>(
                name: "ComapnayId",
                table: "CompanyClaims",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "CompanyClaims",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims",
                column: "ComapnayId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "CompanyClaims");

            migrationBuilder.AlterColumn<int>(
                name: "ComapnayId",
                table: "CompanyClaims",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_Companies_ComapnayId",
                table: "CompanyClaims",
                column: "ComapnayId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
