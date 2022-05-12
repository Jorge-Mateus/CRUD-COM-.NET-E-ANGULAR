using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstruturaOrganizacional.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORGANIZATIONALSTRUCTURE",
                columns: table => new
                {
                    BusinessAreasID = table.Column<int>(type: "int", nullable: false),
                    MarketAreasId = table.Column<int>(type: "int", nullable: false),
                    TchnologicalAreasID = table.Column<int>(type: "int", nullable: false),
                    OperatingUnitsID = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    ano = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATIONALSTRUCTURE", x => new { x.BusinessAreasID, x.MarketAreasId, x.OperatingUnitsID, x.TchnologicalAreasID });
                });

            migrationBuilder.CreateTable(
                name: "BUSINESSAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codEMS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationalStructureBusinessAreasID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureMarketAreasId = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureOperatingUnitsID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureTchnologicalAreasID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSINESSAREA", x => x.id);
                    table.ForeignKey(
                        name: "FK_BUSINESSAREA_ORGANIZATIONALSTRUCTURE_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_Organizatio~",
                        columns: x => new { x.OrganizationalStructureBusinessAreasID, x.OrganizationalStructureMarketAreasId, x.OrganizationalStructureOperatingUnitsID, x.OrganizationalStructureTchnologicalAreasID },
                        principalTable: "ORGANIZATIONALSTRUCTURE",
                        principalColumns: new[] { "BusinessAreasID", "MarketAreasId", "OperatingUnitsID", "TchnologicalAreasID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MARKETAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationalStructureBusinessAreasID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureMarketAreasId = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureOperatingUnitsID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureTchnologicalAreasID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARKETAREA", x => x.id);
                    table.ForeignKey(
                        name: "FK_MARKETAREA_ORGANIZATIONALSTRUCTURE_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_Organizationa~",
                        columns: x => new { x.OrganizationalStructureBusinessAreasID, x.OrganizationalStructureMarketAreasId, x.OrganizationalStructureOperatingUnitsID, x.OrganizationalStructureTchnologicalAreasID },
                        principalTable: "ORGANIZATIONALSTRUCTURE",
                        principalColumns: new[] { "BusinessAreasID", "MarketAreasId", "OperatingUnitsID", "TchnologicalAreasID" },
                        onDelete: ReferentialAction.Restrict);
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
                    OrganizationalStructureBusinessAreasID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureMarketAreasId = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureOperatingUnitsID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureTchnologicalAreasID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATINGUNIT", x => x.id);
                    table.ForeignKey(
                        name: "FK_OPERATINGUNIT_ORGANIZATIONALSTRUCTURE_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_Organizati~",
                        columns: x => new { x.OrganizationalStructureBusinessAreasID, x.OrganizationalStructureMarketAreasId, x.OrganizationalStructureOperatingUnitsID, x.OrganizationalStructureTchnologicalAreasID },
                        principalTable: "ORGANIZATIONALSTRUCTURE",
                        principalColumns: new[] { "BusinessAreasID", "MarketAreasId", "OperatingUnitsID", "TchnologicalAreasID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TECHNOLOGICALAREA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeVirtual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationalStructureBusinessAreasID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureMarketAreasId = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureOperatingUnitsID = table.Column<int>(type: "int", nullable: true),
                    OrganizationalStructureTchnologicalAreasID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TECHNOLOGICALAREA", x => x.id);
                    table.ForeignKey(
                        name: "FK_TECHNOLOGICALAREA_ORGANIZATIONALSTRUCTURE_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_Organi~",
                        columns: x => new { x.OrganizationalStructureBusinessAreasID, x.OrganizationalStructureMarketAreasId, x.OrganizationalStructureOperatingUnitsID, x.OrganizationalStructureTchnologicalAreasID },
                        principalTable: "ORGANIZATIONALSTRUCTURE",
                        principalColumns: new[] { "BusinessAreasID", "MarketAreasId", "OperatingUnitsID", "TchnologicalAreasID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BUSINESSAREA_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_OrganizationalStructureOperatingUni~",
                table: "BUSINESSAREA",
                columns: new[] { "OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID" });

            migrationBuilder.CreateIndex(
                name: "IX_MARKETAREA_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_OrganizationalStructureOperatingUnits~",
                table: "MARKETAREA",
                columns: new[] { "OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID" });

            migrationBuilder.CreateIndex(
                name: "IX_OPERATINGUNIT_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_OrganizationalStructureOperatingUn~",
                table: "OPERATINGUNIT",
                columns: new[] { "OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID" });

            migrationBuilder.CreateIndex(
                name: "IX_TECHNOLOGICALAREA_OrganizationalStructureBusinessAreasID_OrganizationalStructureMarketAreasId_OrganizationalStructureOperati~",
                table: "TECHNOLOGICALAREA",
                columns: new[] { "OrganizationalStructureBusinessAreasID", "OrganizationalStructureMarketAreasId", "OrganizationalStructureOperatingUnitsID", "OrganizationalStructureTchnologicalAreasID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUSINESSAREA");

            migrationBuilder.DropTable(
                name: "MARKETAREA");

            migrationBuilder.DropTable(
                name: "OPERATINGUNIT");

            migrationBuilder.DropTable(
                name: "TECHNOLOGICALAREA");

            migrationBuilder.DropTable(
                name: "ORGANIZATIONALSTRUCTURE");
        }
    }
}
