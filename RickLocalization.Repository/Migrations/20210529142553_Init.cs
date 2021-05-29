using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RickLocalization.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_DIMENSIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_DIMENSIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_HUMANS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_HUMANS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_HUMANS_BY_DIMENSIONS",
                columns: table => new
                {
                    ID_HUMAN = table.Column<int>(type: "int", nullable: false),
                    ID_DIMENSION = table.Column<int>(type: "int", nullable: false),
                    ID_RESPONSIBLE_FOR_WHICH_HUMAN = table.Column<int>(type: "int", nullable: true),
                    ID_HUMAN_RESPONSIBLE_FOR_ME = table.Column<int>(type: "int", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_HUMANS_BY_DIMENSIONS", x => new { x.ID_HUMAN, x.ID_DIMENSION });
                    table.ForeignKey(
                        name: "FK_HUMANS_BY_DIMENSIONS_DIMENSIONS",
                        column: x => x.ID_DIMENSION,
                        principalTable: "TBL_DIMENSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUMANS_BY_DIMENSIONS_HUMAN",
                        column: x => x.ID_HUMAN,
                        principalTable: "TBL_HUMANS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUMANS_BY_DIMENSIONS_HUMAN_RESPONSIBLE_FOR_ME",
                        column: x => x.ID_HUMAN_RESPONSIBLE_FOR_ME,
                        principalTable: "TBL_HUMANS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HUMANS_BY_DIMENSIONS_RESPONSIBLE_FOR_WHICH_HUMAN",
                        column: x => x.ID_RESPONSIBLE_FOR_WHICH_HUMAN,
                        principalTable: "TBL_HUMANS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_TRAVEL_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHumansByDimensions = table.Column<int>(type: "int", nullable: false),
                    ID_TARGET_DIMENSION = table.Column<int>(type: "int", nullable: false),
                    TRAVEL_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HumansByDimensionsIdHuman = table.Column<int>(type: "int", nullable: true),
                    HumansByDimensionsIdDimension = table.Column<int>(type: "int", nullable: true),
                    DimensionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TRAVEL_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_TRAVEL_HISTORY_TBL_DIMENSIONS_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "TBL_DIMENSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_TRAVEL_HISTORY_TBL_HUMANS_BY_DIMENSIONS_HumansByDimensionsIdHuman_HumansByDimensionsIdDimension",
                        columns: x => new { x.HumansByDimensionsIdHuman, x.HumansByDimensionsIdDimension },
                        principalTable: "TBL_HUMANS_BY_DIMENSIONS",
                        principalColumns: new[] { "ID_HUMAN", "ID_DIMENSION" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TBL_DIMENSIONS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "CRONENBERG C-137" },
                    { 2, "WASTELAND" },
                    { 3, "DOG" },
                    { 4, "TOILET" },
                    { 5, "FURNITURE/PIZZA/PHONE WORLDS" },
                    { 6, "NEW CRONENBERG WORLD" },
                    { 7, "FROOPYLAND" },
                    { 8, "TESTICLE MONSTER WORLD" },
                    { 9, "GREASY GRANDMA WORLD" },
                    { 10, "HAMSTER-IN-BUTT WORLD" }
                });

            migrationBuilder.InsertData(
                table: "TBL_HUMANS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Rick Sanchez" },
                    { 2, "Morty" }
                });

            migrationBuilder.InsertData(
                table: "TBL_HUMANS_BY_DIMENSIONS",
                columns: new[] { "ID_DIMENSION", "ID_HUMAN", "ID", "ID_HUMAN_RESPONSIBLE_FOR_ME", "ID_RESPONSIBLE_FOR_WHICH_HUMAN" },
                values: new object[] { 1, 1, 1, null, 2 });

            migrationBuilder.InsertData(
                table: "TBL_HUMANS_BY_DIMENSIONS",
                columns: new[] { "ID_DIMENSION", "ID_HUMAN", "ID", "ID_HUMAN_RESPONSIBLE_FOR_ME", "ID_RESPONSIBLE_FOR_WHICH_HUMAN" },
                values: new object[] { 1, 2, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_HUMANS_BY_DIMENSIONS_ID_DIMENSION",
                table: "TBL_HUMANS_BY_DIMENSIONS",
                column: "ID_DIMENSION");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_HUMANS_BY_DIMENSIONS_ID_HUMAN_RESPONSIBLE_FOR_ME",
                table: "TBL_HUMANS_BY_DIMENSIONS",
                column: "ID_HUMAN_RESPONSIBLE_FOR_ME");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_HUMANS_BY_DIMENSIONS_ID_RESPONSIBLE_FOR_WHICH_HUMAN",
                table: "TBL_HUMANS_BY_DIMENSIONS",
                column: "ID_RESPONSIBLE_FOR_WHICH_HUMAN");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TRAVEL_HISTORY_DimensionsId",
                table: "TBL_TRAVEL_HISTORY",
                column: "DimensionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TRAVEL_HISTORY_HumansByDimensionsIdHuman_HumansByDimensionsIdDimension",
                table: "TBL_TRAVEL_HISTORY",
                columns: new[] { "HumansByDimensionsIdHuman", "HumansByDimensionsIdDimension" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_TRAVEL_HISTORY");

            migrationBuilder.DropTable(
                name: "TBL_HUMANS_BY_DIMENSIONS");

            migrationBuilder.DropTable(
                name: "TBL_DIMENSIONS");

            migrationBuilder.DropTable(
                name: "TBL_HUMANS");
        }
    }
}
