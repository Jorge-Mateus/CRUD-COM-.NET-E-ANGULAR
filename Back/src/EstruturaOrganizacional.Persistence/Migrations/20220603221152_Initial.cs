using Microsoft.EntityFrameworkCore.Migrations;

namespace EstruturaOrganizacional.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BUSINESSAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codEMS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSINESSAREA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MARKETAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARKETAREA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OPERATINGUNIT",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codReduzido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATINGUNIT", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TECHNOLOGICALAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeVirtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TECHNOLOGICALAREA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ORGANIZATIONALSTRUCTURE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    BusinessAreaId = table.Column<int>(type: "int", nullable: false),
                    MarketAreaID = table.Column<int>(type: "int", nullable: false),
                    TechnologicalAreaId = table.Column<int>(type: "int", nullable: false),
                    OperatingUnitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATIONALSTRUCTURE", x => x.id);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_BUSINESSAREA_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BUSINESSAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_MARKETAREA_MarketAreaID",
                        column: x => x.MarketAreaID,
                        principalTable: "MARKETAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_OPERATINGUNIT_OperatingUnitsId",
                        column: x => x.OperatingUnitsId,
                        principalTable: "OPERATINGUNIT",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_TECHNOLOGICALAREA_TechnologicalAreaId",
                        column: x => x.TechnologicalAreaId,
                        principalTable: "TECHNOLOGICALAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_BusinessAreaId",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_MarketAreaID",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "MarketAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_OperatingUnitsId",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "OperatingUnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_TechnologicalAreaId",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "TechnologicalAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORGANIZATIONALSTRUCTURE");

            migrationBuilder.DropTable(
                name: "BUSINESSAREA");

            migrationBuilder.DropTable(
                name: "MARKETAREA");

            migrationBuilder.DropTable(
                name: "OPERATINGUNIT");

            migrationBuilder.DropTable(
                name: "TECHNOLOGICALAREA");
        }
    }
}
