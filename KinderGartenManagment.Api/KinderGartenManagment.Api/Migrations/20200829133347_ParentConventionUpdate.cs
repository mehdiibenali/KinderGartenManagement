using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class ParentConventionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_ConventionId",
                table: "Parents");

            migrationBuilder.CreateTable(
                name: "ParentConventions",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false),
                    ConventionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentConventions", x => new { x.ParentId, x.ConventionId });
                    table.ForeignKey(
                        name: "FK_ParentConventions_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalTable: "Conventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentConventions_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentConventions_ConventionId",
                table: "ParentConventions",
                column: "ConventionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentConventions");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ConventionId",
                table: "Parents",
                column: "ConventionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Conventions_ConventionId",
                table: "Parents",
                column: "ConventionId",
                principalTable: "Conventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
