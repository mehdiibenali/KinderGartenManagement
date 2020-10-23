using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveEnrollementIdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements",
                columns: new[] { "EleveId", "EnrollementId", "DateDeDebut" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EleveEnrollements",
                table: "EleveEnrollements",
                columns: new[] { "EleveId", "EnrollementId" });
        }
    }
}
