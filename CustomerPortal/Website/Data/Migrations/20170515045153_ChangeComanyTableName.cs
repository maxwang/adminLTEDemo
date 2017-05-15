using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Data.Migrations
{
    public partial class ChangeComanyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyClaims_Companies_CompanyId",
                table: "CompanyClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyClaims",
                table: "CompanyClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "CompanyClaims",
                newName: "AspNetCompanyClaims");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "AspNetCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyClaims_CompanyId",
                table: "AspNetCompanyClaims",
                newName: "IX_AspNetCompanyClaims_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetCompanyClaims",
                table: "AspNetCompanyClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetCompanies",
                table: "AspNetCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetCompanies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "AspNetCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetCompanyClaims_AspNetCompanies_CompanyId",
                table: "AspNetCompanyClaims",
                column: "CompanyId",
                principalTable: "AspNetCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetCompanies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetCompanyClaims_AspNetCompanies_CompanyId",
                table: "AspNetCompanyClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetCompanyClaims",
                table: "AspNetCompanyClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetCompanies",
                table: "AspNetCompanies");

            migrationBuilder.RenameTable(
                name: "AspNetCompanyClaims",
                newName: "CompanyClaims");

            migrationBuilder.RenameTable(
                name: "AspNetCompanies",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetCompanyClaims_CompanyId",
                table: "CompanyClaims",
                newName: "IX_CompanyClaims_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyClaims",
                table: "CompanyClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyClaims_Companies_CompanyId",
                table: "CompanyClaims",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
