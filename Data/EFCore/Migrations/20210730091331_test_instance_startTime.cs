using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.EFCore.Migrations
{
    public partial class test_instance_startTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "TestInstances",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TestInstances");
        }
    }
}
