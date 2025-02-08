using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frodo.Pets.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePetDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pets");

            migrationBuilder.CreateTable(
                name: "Medications",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mandatory = table.Column<bool>(type: "bit", nullable: false),
                    IsVaccine = table.Column<bool>(type: "bit", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetUsers",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetUsers_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pets",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetVaccines",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetVaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetVaccines_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pets",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetVaccineDates",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetVaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevaccinateIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetVaccineDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetVaccineDates_PetVaccines_PetVaccineId",
                        column: x => x.PetVaccineId,
                        principalSchema: "Pets",
                        principalTable: "PetVaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetUsers_PetId",
                schema: "Pets",
                table: "PetUsers",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccineDates_PetVaccineId",
                schema: "Pets",
                table: "PetVaccineDates",
                column: "PetVaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_PetVaccines_PetId",
                schema: "Pets",
                table: "PetVaccines",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "PetUsers",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "PetVaccineDates",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "PetVaccines",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "Pets",
                schema: "Pets");
        }
    }
}
