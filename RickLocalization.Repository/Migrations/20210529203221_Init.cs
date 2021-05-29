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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_HUMAN = table.Column<int>(type: "int", nullable: false),
                    ID_DIMENSION = table.Column<int>(type: "int", nullable: false),
                    ID_RESPONSIBLE_FOR_WHICH_HUMAN = table.Column<int>(type: "int", nullable: true),
                    ID_HUMAN_RESPONSIBLE_FOR_ME = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_HUMANS_BY_DIMENSIONS", x => x.ID);
                    table.UniqueConstraint("AK_TBL_HUMANS_BY_DIMENSIONS_ID_HUMAN_ID_DIMENSION", x => new { x.ID_HUMAN, x.ID_DIMENSION });
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
                    ID_HUMANS_DIMENSION = table.Column<int>(type: "int", nullable: false),
                    ID_TARGET_DIMENSION = table.Column<int>(type: "int", nullable: false),
                    TRAVEL_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TRAVEL_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRAVEL_HISTORY_DIMENSIONS",
                        column: x => x.ID_TARGET_DIMENSION,
                        principalTable: "TBL_DIMENSIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRAVEL_HISTORY_HUMANS_DIMENSIONS",
                        column: x => x.ID_HUMANS_DIMENSION,
                        principalTable: "TBL_HUMANS_BY_DIMENSIONS",
                        principalColumn: "ID",
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
                columns: new[] { "ID", "ID_DIMENSION", "ID_HUMAN", "ID_HUMAN_RESPONSIBLE_FOR_ME", "ID_RESPONSIBLE_FOR_WHICH_HUMAN" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 2 },
                    { 18, 9, 2, 1, null },
                    { 17, 9, 1, null, 2 },
                    { 16, 8, 2, 1, null },
                    { 15, 8, 1, null, 2 },
                    { 14, 7, 2, 1, null },
                    { 13, 7, 1, null, 2 },
                    { 12, 6, 2, 1, null },
                    { 11, 6, 1, null, 2 },
                    { 10, 5, 2, 1, null },
                    { 9, 5, 1, null, 2 },
                    { 8, 4, 2, 1, null },
                    { 7, 4, 1, null, 2 },
                    { 6, 3, 2, 1, null },
                    { 5, 3, 1, null, 2 },
                    { 4, 2, 2, 1, null },
                    { 3, 2, 1, null, 2 },
                    { 2, 1, 2, 1, null },
                    { 19, 10, 1, null, 2 },
                    { 20, 10, 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "TBL_TRAVEL_HISTORY",
                columns: new[] { "ID", "ID_HUMANS_DIMENSION", "ID_TARGET_DIMENSION", "TRAVEL_DATE" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2021, 1, 3, 8, 0, 15, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 4, new DateTime(2021, 4, 1, 8, 0, 15, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 6, new DateTime(2021, 1, 3, 8, 0, 15, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 2, new DateTime(2021, 4, 1, 8, 0, 15, 0, DateTimeKind.Unspecified) }
                });

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
                name: "IX_TBL_TRAVEL_HISTORY_ID_HUMANS_DIMENSION",
                table: "TBL_TRAVEL_HISTORY",
                column: "ID_HUMANS_DIMENSION");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_TRAVEL_HISTORY_ID_TARGET_DIMENSION",
                table: "TBL_TRAVEL_HISTORY",
                column: "ID_TARGET_DIMENSION");
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
