using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EFCore.Migrations
{
    public partial class test_instance_errors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NegativeResponses",
                table: "TestInstances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativeResponses",
                table: "TestInstances");
        }
    }
}
