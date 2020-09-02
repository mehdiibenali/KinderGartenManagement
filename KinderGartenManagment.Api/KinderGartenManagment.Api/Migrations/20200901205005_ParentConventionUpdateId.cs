using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class ParentConventionUpdateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentConventions",
                table: "ParentConventions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentConventions",
                table: "ParentConventions",
                columns: new[] { "ParentId", "ConventionId", "DateDeDebut" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentConventions",
                table: "ParentConventions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentConventions",
                table: "ParentConventions",
                columns: new[] { "ParentId", "ConventionId" });
        }
    }
}
