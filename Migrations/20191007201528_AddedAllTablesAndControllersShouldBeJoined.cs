using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace capstone_backend.Migrations
{
    public partial class AddedAllTablesAndControllersShouldBeJoined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Assignments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PatientEmergencyLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEmergencyLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientEmergencyLogs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Emotions = table.Column<string>(nullable: true),
                    Triggers = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientLogs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientEmergencyLogs_PatientId",
                table: "PatientEmergencyLogs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLogs_PatientId",
                table: "PatientLogs",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientEmergencyLogs");

            migrationBuilder.DropTable(
                name: "PatientLogs");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "Assignments");
        }
    }
}
