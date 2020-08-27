using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class conventionparent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnneDeFin",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "AnneeDeDebut",
                table: "Groupes");

            migrationBuilder.AddColumn<int>(
                name: "ConventionId",
                table: "Parents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DateDeDebut",
                table: "Groupes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateDeFin",
                table: "Groupes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateDeNaissance",
                table: "Eleves",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Conventions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conventions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ConventionId",
                table: "Parents",
                column: "ConventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents",
                column: "ConventionId",
                principalTable: "Conventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents");

            migrationBuilder.DropTable(
                name: "Conventions");

            migrationBuilder.DropIndex(
                name: "IX_Parents_ConventionId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "ConventionId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "Groupes");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
                table: "Groupes");

            migrationBuilder.AddColumn<int>(
                name: "AnneDeFin",
                table: "Groupes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnneeDeDebut",
                table: "Groupes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeNaissance",
                table: "Eleves",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
