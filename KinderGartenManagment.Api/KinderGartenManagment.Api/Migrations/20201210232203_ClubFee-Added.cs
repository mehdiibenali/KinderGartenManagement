using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGartenManagment.Api.Migrations
{
    public partial class ClubFeeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fee",
                table: "Enrollements",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UnpaidViewModel",
                columns: table => new
                {
                    EleveId = table.Column<int>(nullable: false),
                    Prenom = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    EnrollementId = table.Column<int>(nullable: true),
                    EnrollementName = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    EleveEnrollementId = table.Column<int>(nullable: true),
                    DateDeDebut = table.Column<string>(nullable: true),
                    DateDeFin = table.Column<string>(nullable: true),
                    Paid = table.Column<int>(nullable: true),
                    Max = table.Column<string>(nullable: true),
                    EnrollementPaid = table.Column<string>(nullable: true),
                    ConventionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnpaidViewModel");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Enrollements");
        }
    }
}
