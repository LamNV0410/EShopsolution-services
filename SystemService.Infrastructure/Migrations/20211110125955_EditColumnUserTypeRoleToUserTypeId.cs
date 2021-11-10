using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Infrastructure.Migrations
{
    public partial class EditColumnUserTypeRoleToUserTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeRole",
                schema: "SystemService",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeId",
                schema: "SystemService",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeId",
                schema: "SystemService",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeRole",
                schema: "SystemService",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
