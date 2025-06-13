using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancerApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsArchived = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FreelancerId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hobbies_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hobbies_Freelancers_FreelancerId1",
                        column: x => x.FreelancerId1,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skillsets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FreelancerId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skillsets_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skillsets_Freelancers_FreelancerId1",
                        column: x => x.FreelancerId1,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_FreelancerId",
                table: "Hobbies",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_FreelancerId1",
                table: "Hobbies",
                column: "FreelancerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Skillsets_FreelancerId",
                table: "Skillsets",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skillsets_FreelancerId1",
                table: "Skillsets",
                column: "FreelancerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Skillsets");

            migrationBuilder.DropTable(
                name: "Freelancers");
        }
    }
}
