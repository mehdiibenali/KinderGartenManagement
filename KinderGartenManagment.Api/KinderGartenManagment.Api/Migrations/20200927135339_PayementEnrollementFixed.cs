using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class PayementEnrollementFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "PayementEnrollements");

            migrationBuilder.DropIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
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

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "PayementEnrollements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "PayementEnrollements");

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

            migrationBuilder.AddColumn<int>(
                name: "EleveEnrollementId",
                table: "PayementEnrollements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayementEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "PayementEnrollements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PayementEnrollements_EleveEnrollements_EleveEnrollementEleveId_EleveEnrollementEnrollementId",
                table: "PayementEnrollements",
                columns: new[] { "EleveEnrollementEleveId", "EleveEnrollementEnrollementId" },
                principalTable: "EleveEnrollements",
                principalColumns: new[] { "EleveId", "EnrollementId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
