using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Infrastructure.Migrations
{
    public partial class Addusertyperole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypeRoles",
                schema: "SystemService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UserTypeRoleName = table.Column<string>(nullable: true),
                    UserTypeRoleCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeRoles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypeRoles",
                schema: "SystemService");
        }
    }
}
