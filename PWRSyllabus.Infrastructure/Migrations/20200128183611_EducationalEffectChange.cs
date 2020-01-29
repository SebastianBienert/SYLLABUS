using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class EducationalEffectChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "EducationalEffects");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "EducationalEffects");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EducationalEffects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EducationalEffects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Umie robić ciekawe rzeczy.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EducationalEffects");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "EducationalEffects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "EducationalEffects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "EducationalEffects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Level", "Profile" },
                values: new object[] { "St1Inzynier", "Practical" });
        }
    }
}
