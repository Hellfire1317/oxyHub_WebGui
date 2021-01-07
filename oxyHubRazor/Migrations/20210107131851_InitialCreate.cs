using Microsoft.EntityFrameworkCore.Migrations;

namespace oxyHubRazor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mqttData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feuchtigkeit = table.Column<int>(type: "int", nullable: false),
                    temperatur = table.Column<int>(type: "int", nullable: false),
                    tvoc = table.Column<int>(type: "int", nullable: false),
                    eco2 = table.Column<int>(type: "int", nullable: false),
                    airQuality = table.Column<int>(type: "int", nullable: false),
                    airQualityPrecision = table.Column<int>(type: "int", nullable: false),
                    rawh2 = table.Column<int>(type: "int", nullable: false),
                    rawEthanol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mqttData", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mqttData");
        }
    }
}
