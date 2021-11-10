using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Infrastructure.Migrations
{
    public partial class EditUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeRoleId",
                schema: "SystemService",
                table: "UserTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTypeRoleId",
                schema: "SystemService",
                table: "UserTypes");
        }
    }
}
