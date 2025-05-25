using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frodo.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Pets");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Race = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MicrochipId = table.Column<string>(type: "text", nullable: true),
                    FavoriteFood = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TakenIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    OtherDuration = table.Column<string>(type: "text", nullable: true),
                    PetId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pets",
                        principalTable: "Pets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutors_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pets",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DoctorName = table.Column<string>(type: "text", nullable: true),
                    Laboratory = table.Column<string>(type: "text", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_Pets_PetId",
                        column: x => x.PetId,
                        principalSchema: "Pets",
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVerificationTokens",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    VerificationToken = table.Column<string>(type: "text", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerificationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVerificationTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccineDates",
                schema: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetVaccineId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RevaccinateIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccineDates_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalSchema: "Pets",
                        principalTable: "Vaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PetId",
                schema: "Pets",
                table: "Medications",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_PetId",
                schema: "Pets",
                table: "Tutors",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerificationTokens_UserId",
                schema: "Users",
                table: "UserVerificationTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineDates_VaccineId",
                schema: "Pets",
                table: "VaccineDates",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_PetId",
                schema: "Pets",
                table: "Vaccines",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "Tutors",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "UserVerificationTokens",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "VaccineDates",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Vaccines",
                schema: "Pets");

            migrationBuilder.DropTable(
                name: "Pets",
                schema: "Pets");
        }
    }
}
