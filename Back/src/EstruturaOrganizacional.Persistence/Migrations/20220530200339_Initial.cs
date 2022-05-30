using System;
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
                    ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessAreasid = table.Column<int>(type: "int", nullable: true),
                    MarketAreasid = table.Column<int>(type: "int", nullable: true),
                    TchnologicalAreasid = table.Column<int>(type: "int", nullable: true),
                    OperatingUnitsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATIONALSTRUCTURE", x => x.id);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_BUSINESSAREA_BusinessAreasid",
                        column: x => x.BusinessAreasid,
                        principalTable: "BUSINESSAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_MARKETAREA_MarketAreasid",
                        column: x => x.MarketAreasid,
                        principalTable: "MARKETAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_OPERATINGUNIT_OperatingUnitsid",
                        column: x => x.OperatingUnitsid,
                        principalTable: "OPERATINGUNIT",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORGANIZATIONALSTRUCTURE_TECHNOLOGICALAREA_TchnologicalAreasid",
                        column: x => x.TchnologicalAreasid,
                        principalTable: "TECHNOLOGICALAREA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_BusinessAreasid",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "BusinessAreasid");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_MarketAreasid",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "MarketAreasid");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_OperatingUnitsid",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "OperatingUnitsid");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONALSTRUCTURE_TchnologicalAreasid",
                table: "ORGANIZATIONALSTRUCTURE",
                column: "TchnologicalAreasid");
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
