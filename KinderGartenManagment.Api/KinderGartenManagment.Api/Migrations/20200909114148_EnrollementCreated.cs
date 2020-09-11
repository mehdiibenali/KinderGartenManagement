using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EnrollementCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements");

            migrationBuilder.DropTable(
                name: "EleveGroupes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "Payements");

            migrationBuilder.AlterColumn<int>(
                name: "EleveId",
                table: "Payements",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Payements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEleveId",
                table: "Payements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEnrollementId",
                table: "Payements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementId",
                table: "Payements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enrollements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DateDeDebut = table.Column<DateTime>(nullable: false),
                    DateDeFin = table.Column<DateTime>(nullable: false),
                    ClasseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollements_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EleveEnrollements",
                columns: table => new
                {
                    EleveId = table.Column<int>(nullable: false),
                    EnrollementId = table.Column<int>(nullable: false),
                    DateDeDebut = table.Column<DateTime>(nullable: false),
                    DateDeFin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleveEnrollements", x => new { x.EleveId, x.EnrollementId });
                    table.ForeignKey(
                        name: "FK_EleveEnrollements_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleveEnrollements_Enrollements_EnrollementId",
                        column: x => x.EnrollementId,
                        principalTable: "Enrollements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" });

            migrationBuilder.CreateIndex(
                name: "IX_EleveEnrollements_EnrollementId",
                table: "EleveEnrollements",
                column: "EnrollementId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollements_ClasseId",
                table: "Enrollements",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements",
                column: "EleveId",
                principalTable: "Eleves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" },
                principalTable: "EleveEnrollements",
                principalColumns: new[] { "EleveId", "EnrollementId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements");

            migrationBuilder.DropForeignKey(
                name: "FK_Payements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements");

            migrationBuilder.DropTable(
                name: "EleveEnrollements");

            migrationBuilder.DropTable(
                name: "Enrollements");

            migrationBuilder.DropIndex(
                name: "IX_Payements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEleveId",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEnrollementId",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementId",
                table: "Payements");

            migrationBuilder.AlterColumn<int>(
                name: "EleveId",
                table: "Payements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionType",
                table: "Payements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    DateDeDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EleveGroupes",
                columns: table => new
                {
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    DateDeDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeFin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleveGroupes", x => new { x.EleveId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_EleveGroupes_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleveGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EleveGroupes_GroupeId",
                table: "EleveGroupes",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_ClasseId",
                table: "Groupes",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements",
                column: "EleveId",
                principalTable: "Eleves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
