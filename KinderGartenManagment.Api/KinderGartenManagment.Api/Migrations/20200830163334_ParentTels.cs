using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class ParentTels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelDomicile",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "TelPortable",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "Tel1",
                table: "Parents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tel2",
                table: "Parents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tel3",
                table: "Parents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel1",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Tel2",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Tel3",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "TelDomicile",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelPortable",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
