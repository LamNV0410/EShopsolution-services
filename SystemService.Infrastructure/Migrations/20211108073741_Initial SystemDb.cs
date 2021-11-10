using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemService.Infrastructure.Migrations
{
    public partial class InitialSystemDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "SystemService",
                table: "UserTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                schema: "SystemService",
                table: "UserTypes");
        }
    }
}
