using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModel.Migrations
{
    public partial class AddWeatherMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectionWinds",
                columns: table => new
                {
                    DirectionWindId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectionWinds", x => x.DirectionWindId);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    WeatherConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.WeatherConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeMeasuring = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    Td = table.Column<double>(nullable: false),
                    Atmosphere = table.Column<int>(nullable: false),
                    SpeedWind = table.Column<int>(nullable: false),
                    OverCast = table.Column<int>(nullable: false),
                    H = table.Column<int>(nullable: false),
                    VW = table.Column<int>(nullable: true),
                    WeatherConditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_Weathers_WeatherConditions_WeatherConditionId",
                        column: x => x.WeatherConditionId,
                        principalTable: "WeatherConditions",
                        principalColumn: "WeatherConditionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDirectionWinds",
                columns: table => new
                {
                    WeatherDirectionWindId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WeatherId = table.Column<int>(nullable: true),
                    DirectionWindId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDirectionWinds", x => x.WeatherDirectionWindId);
                    table.ForeignKey(
                        name: "FK_WeatherDirectionWinds_DirectionWinds_DirectionWindId",
                        column: x => x.DirectionWindId,
                        principalTable: "DirectionWinds",
                        principalColumn: "DirectionWindId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherDirectionWinds_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "WeatherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDirectionWinds_DirectionWindId",
                table: "WeatherDirectionWinds",
                column: "DirectionWindId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDirectionWinds_WeatherId",
                table: "WeatherDirectionWinds",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Weathers_WeatherConditionId",
                table: "Weathers",
                column: "WeatherConditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDirectionWinds");

            migrationBuilder.DropTable(
                name: "DirectionWinds");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropTable(
                name: "WeatherConditions");
        }
    }
}
