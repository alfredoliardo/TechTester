using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EFCore.Migrations
{
    public partial class damaged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Damaged",
                table: "TestInstances",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Damaged",
                table: "TestInstances");
        }
    }
}
