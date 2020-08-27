using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class EleveGroupe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EleveGroupes",
                columns: table => new
                {
                    EleveId = table.Column<int>(nullable: false),
                    GroupeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EleveGroupes", x => new { x.EleveId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_EleveGroupes_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EleveGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EleveGroupes_GroupeId",
                table: "EleveGroupes",
                column: "GroupeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EleveGroupes");
        }
    }
}
