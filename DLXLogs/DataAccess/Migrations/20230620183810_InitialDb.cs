using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceVendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceVersion = table.Column<double>(type: "float", nullable: false),
                    SignatureId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Rt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dhost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dmac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<int>(type: "int", nullable: false),
                    Cs1Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cs1 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
