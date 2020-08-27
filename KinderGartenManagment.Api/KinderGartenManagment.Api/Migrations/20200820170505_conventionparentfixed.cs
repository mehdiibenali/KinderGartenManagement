using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class conventionparentfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "ConventionId",
                table: "Parents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents",
                column: "ConventionId",
                principalTable: "Conventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "ConventionId",
                table: "Parents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents",
                column: "ConventionId",
                principalTable: "Conventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
