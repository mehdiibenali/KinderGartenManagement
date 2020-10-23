using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveAddedInPayement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements");

            migrationBuilder.AlterColumn<int>(
                name: "EleveId",
                table: "Payements",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnrollementId",
                table: "PayementEnrollements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EnrollementId",
                table: "PayementEnrollements",
                column: "EnrollementId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_Enrollements_EnrollementId",
                table: "PayementEnrollements",
                column: "EnrollementId",
                principalTable: "Enrollements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements",
                column: "EleveId",
                principalTable: "Eleves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_Enrollements_EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropColumn(
                name: "EnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.AlterColumn<int>(
                name: "EleveId",
                table: "Payements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Payements_Eleves_EleveId",
                table: "Payements",
                column: "EleveId",
                principalTable: "Eleves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
