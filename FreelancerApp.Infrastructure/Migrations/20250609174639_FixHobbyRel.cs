using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelancerApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixHobbyRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Freelancers_FreelancerId1",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Skillsets_Freelancers_FreelancerId1",
                table: "Skillsets");

            migrationBuilder.DropIndex(
                name: "IX_Skillsets_FreelancerId1",
                table: "Skillsets");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_FreelancerId1",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "FreelancerId1",
                table: "Skillsets");

            migrationBuilder.DropColumn(
                name: "FreelancerId1",
                table: "Hobbies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FreelancerId1",
                table: "Skillsets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FreelancerId1",
                table: "Hobbies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Skillsets_FreelancerId1",
                table: "Skillsets",
                column: "FreelancerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_FreelancerId1",
                table: "Hobbies",
                column: "FreelancerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Freelancers_FreelancerId1",
                table: "Hobbies",
                column: "FreelancerId1",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skillsets_Freelancers_FreelancerId1",
                table: "Skillsets",
                column: "FreelancerId1",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
