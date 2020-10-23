using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveIdAddedInPayementEnrollement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements");

            migrationBuilder.DropIndex(
                name: "IX_Payements_EleveId",
                table: "Payements");

            migrationBuilder.DropColumn(
                name: "EleveId",
                table: "Payements");

            migrationBuilder.AddColumn<int>(
                name: "EleveId",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EleveId",
                table: "PayementEnrollements",
                column: "EleveId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_Eleves_EleveId",
                table: "PayementEnrollements",
                column: "EleveId",
                principalTable: "Eleves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_Eleves_EleveId",
                table: "PayementEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EleveId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EleveId",
                table: "PayementEnrollements");

            migrationBuilder.AddColumn<int>(
                name: "EleveId",
                table: "Payements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payements_EleveId",
                table: "Payements",
                column: "EleveId");

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
