using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class prenomfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prénom",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Prénom",
                table: "Eleves");

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "Eleves",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "Eleves");

            migrationBuilder.AddColumn<string>(
                name: "Prénom",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prénom",
                table: "Eleves",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
