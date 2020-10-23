using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveEnrollementIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId_EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementDateDeDebut",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEleveId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveEnrollementEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EleveEnrollements",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EleveEnrollementId",
                table: "PayementEnrollements",
                column: "EleveEnrollementId");

            migrationBuilder.CreateIndex(
                name: "IX_EleveEnrollements_EleveId_EnrollementId_DateDeDebut",
                table: "EleveEnrollements",
                columns: new[] { "EleveId", "EnrollementId", "DateDeDebut" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementId",
                table: "PayementEnrollements",
                column: "EleveEnrollementId",
                principalTable: "EleveEnrollements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EleveEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_EleveEnrollements_EleveId_EnrollementId_DateDeDebut",
                table: "EleveEnrollements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EleveEnrollements");

            migrationBuilder.AddColumn<DateTime>(
                name: "EleveEnrollementDateDeDebut",
                table: "PayementEnrollements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEleveId",
                table: "PayementEnrollements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEnrollementId",
                table: "PayementEnrollements",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements",
                columns: new[] { "EleveId", "EnrollementId", "DateDeDebut" });

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
    }
}
