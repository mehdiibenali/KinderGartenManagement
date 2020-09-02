using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class GroupeAndConventionUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ParentConventions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeDebut",
                table: "ParentConventions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeFin",
                table: "ParentConventions",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeFin",
                table: "Groupes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeDebut",
                table: "Groupes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ParentTuteur",
                table: "EleveParents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "EleveGroupes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeDebut",
                table: "EleveGroupes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeFin",
                table: "EleveGroupes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeDebut",
                table: "Conventions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeFin",
                table: "Conventions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "ParentConventions");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "ParentConventions");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
                table: "ParentConventions");

            migrationBuilder.DropColumn(
                name: "ParentTuteur",
                table: "EleveParents");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "EleveGroupes");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "EleveGroupes");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
                table: "EleveGroupes");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "Conventions");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
                table: "Conventions");

            migrationBuilder.AlterColumn<string>(
                name: "DateDeFin",
                table: "Groupes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "DateDeDebut",
                table: "Groupes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
