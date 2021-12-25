using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2021_LazarishinArtur.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeatLossCircleDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diameter = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TempBake = table.Column<double>(type: "REAL", nullable: false),
                    WallThickness = table.Column<double>(type: "REAL", nullable: false),
                    WindowOpenTime = table.Column<double>(type: "REAL", nullable: false),
                    ApertureRatio = table.Column<double>(type: "REAL", nullable: false),
                    RadiationHeatLoss = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatLossCircleDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatLossCircleDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeatLossRectangleDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WidthWindow = table.Column<double>(type: "REAL", nullable: false),
                    HeightWindow = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TempBake = table.Column<double>(type: "REAL", nullable: false),
                    WallThickness = table.Column<double>(type: "REAL", nullable: false),
                    WindowOpenTime = table.Column<double>(type: "REAL", nullable: false),
                    ApertureRatio = table.Column<double>(type: "REAL", nullable: false),
                    RadiationHeatLoss = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatLossRectangleDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatLossRectangleDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeatLossSquaredDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SideLength = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TempBake = table.Column<double>(type: "REAL", nullable: false),
                    WallThickness = table.Column<double>(type: "REAL", nullable: false),
                    WindowOpenTime = table.Column<double>(type: "REAL", nullable: false),
                    ApertureRatio = table.Column<double>(type: "REAL", nullable: false),
                    RadiationHeatLoss = table.Column<double>(type: "REAL", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatLossSquaredDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatLossSquaredDatas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[] { 1, "admin@mail.ru", "admin", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_HeatLossCircleDatas_UserId",
                table: "HeatLossCircleDatas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HeatLossRectangleDatas_UserId",
                table: "HeatLossRectangleDatas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HeatLossSquaredDatas_UserId",
                table: "HeatLossSquaredDatas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeatLossCircleDatas");

            migrationBuilder.DropTable(
                name: "HeatLossRectangleDatas");

            migrationBuilder.DropTable(
                name: "HeatLossSquaredDatas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
