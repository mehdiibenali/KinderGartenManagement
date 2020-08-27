using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EleveParents",
                columns: table => new
                {
                    EleveId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleveParents", x => new { x.EleveId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_EleveParents_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleveParents_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EleveParents_ParentId",
                table: "EleveParents",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EleveParents");
        }
    }
}
