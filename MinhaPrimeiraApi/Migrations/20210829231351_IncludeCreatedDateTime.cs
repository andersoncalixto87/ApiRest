using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaPrimeiraApi.Migrations
{
    public partial class IncludeCreatedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED",
                table: "tbProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED",
                table: "tbProduct");
        }
    }
}
