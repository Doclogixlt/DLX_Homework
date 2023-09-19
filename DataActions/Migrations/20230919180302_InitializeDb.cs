using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataActions.Migrations
{
    public partial class InitializeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchQueries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queryString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchQueryId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDetails_SearchQueries_SearchQueryId",
                        column: x => x.SearchQueryId,
                        principalTable: "SearchQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchQueryId = table.Column<int>(type: "int", nullable: false),
                    deviceVendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviceProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deviceVersion = table.Column<int>(type: "int", nullable: false),
                    signatureId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    severity = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    smac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dhost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dmac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    externalId = table.Column<int>(type: "int", nullable: false),
                    cs1Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cs1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogEntries_SearchQueries_SearchQueryId",
                        column: x => x.SearchQueryId,
                        principalTable: "SearchQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileDetails_SearchQueryId",
                table: "FileDetails",
                column: "SearchQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_SearchQueryId",
                table: "LogEntries",
                column: "SearchQueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileDetails");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "SearchQueries");
        }
    }
}
