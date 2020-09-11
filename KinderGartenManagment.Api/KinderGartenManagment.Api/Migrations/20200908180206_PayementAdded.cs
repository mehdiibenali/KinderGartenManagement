using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class PayementAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tarif",
                table: "ConventionFees");

            migrationBuilder.AddColumn<int>(
                name: "Fee",
                table: "ConventionFees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Payements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDeDebut = table.Column<DateTime>(nullable: false),
                    DateDeFin = table.Column<DateTime>(nullable: false),
                    SubscriptionType = table.Column<string>(nullable: true),
                    Expected = table.Column<int>(nullable: false),
                    Paid = table.Column<string>(nullable: true),
                    EleveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payements_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payements_EleveId",
                table: "Payements",
                column: "EleveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payements");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "ConventionFees");

            migrationBuilder.AddColumn<int>(
                name: "Tarif",
                table: "ConventionFees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
