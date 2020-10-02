using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class PayementCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements");

            migrationBuilder.DropIndex(
                name: "IX_Payements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "DateDeDebut",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "DateDeFin",
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

            migrationBuilder.DropColumn(
                name: "Expected",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Payements");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptNumber",
                table: "Payements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modalites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    CheckNumber = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PayementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalites_Payements_PayementId",
                        column: x => x.PayementId,
                        principalTable: "Payements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayementEnrollements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section = table.Column<string>(nullable: true),
                    Paid = table.Column<int>(nullable: false),
                    PayementId = table.Column<int>(nullable: false),
                    EleveEnrollementId = table.Column<int>(nullable: true),
                    EleveEnrollementEleveId = table.Column<int>(nullable: true),
                    EleveEnrollementEnrollementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayementEnrollements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayementEnrollements_Payements_PayementId",
                        column: x => x.PayementId,
                        principalTable: "Payements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                        columns: x => new { x.EleveEnrollementEleveId, x.EleveEnrollementEnrollementId },
                        principalTable: "EleveEnrollements",
                        principalColumns: new[] { "EleveId", "EnrollementId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayementDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDeDebut = table.Column<DateTime>(nullable: false),
                    DateDeFin = table.Column<DateTime>(nullable: false),
                    PayementEnrollementId = table.Column<int>(nullable: false)
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
                name: "IX_Modalites_PayementId",
                table: "Modalites",
                column: "PayementId");

            migrationBuilder.CreateIndex(
                name: "IX_PayementDates_PayementEnrollementId",
                table: "PayementDates",
                column: "PayementEnrollementId");

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_PayementId",
                table: "PayementEnrollements",
                column: "PayementId");

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "PayementEnrollements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modalites");

            migrationBuilder.DropTable(
                name: "PayementDates");

            migrationBuilder.DropTable(
                name: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                table: "Payements");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Payements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeDebut",
                table: "Payements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeFin",
                table: "Payements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEleveId",
                table: "Payements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementEnrollementId",
                table: "Payements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementId",
                table: "Payements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Expected",
                table: "Payements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Paid",
                table: "Payements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "Payements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" },
                principalTable: "EleveEnrollements",
                principalColumns: new[] { "EleveId", "EnrollementId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
