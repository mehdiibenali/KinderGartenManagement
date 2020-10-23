using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class PayementDatesDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_Enrollements_EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropTable(
                name: "PayementDates");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeDebut",
                table: "PayementEnrollements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeFin",
                table: "PayementEnrollements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EleveEnrollementDateDeDebut",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEleveId",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEnrollementId",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementId",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId", "EleveEnrollementDateDeDebut" });

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId", "EleveEnrollementDateDeDebut" },
                principalTable: "EleveEnrollements",
                principalColumns: new[] { "EleveId", "EnrollementId", "DateDeDebut" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEleveId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.AddColumn<int>(
                name: "EnrollementId",
                table: "PayementEnrollements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PayementDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDeDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayementEnrollementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayementDates_PayementEnrollements_PayementEnrollementId",
                        column: x => x.PayementEnrollementId,
                        principalTable: "PayementEnrollements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EnrollementId",
                table: "PayementEnrollements",
                column: "EnrollementId");

            migrationBuilder.CreateIndex(
                name: "IX_PayementDates_PayementEnrollementId",
                table: "PayementDates",
                column: "PayementEnrollementId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_Enrollements_EnrollementId",
                table: "PayementEnrollements",
                column: "EnrollementId",
                principalTable: "Enrollements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
