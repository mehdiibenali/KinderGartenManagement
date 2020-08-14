using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Employeur",
                table: "Parents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Parents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prénom = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    DateDeNaissance = table.Column<DateTime>(nullable: false),
                    LieuDeNaissance = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Sexe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropColumn(
                name: "Employeur",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Parents");
        }
    }
}
