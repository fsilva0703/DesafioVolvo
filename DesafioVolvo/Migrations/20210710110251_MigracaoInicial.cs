using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioVolvo.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModels",
                columns: table => new
                {
                    TruckModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModels", x => x.TruckModelId);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TruckName = table.Column<string>(nullable: true),
                    TruckModelId = table.Column<int>(nullable: false),
                    ManufactureYear = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.TruckId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckModels");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}