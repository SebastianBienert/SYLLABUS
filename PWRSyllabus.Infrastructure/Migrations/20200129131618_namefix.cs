using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class namefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Objectivties",
                table: "SubjectCards");

            migrationBuilder.AddColumn<string>(
                name: "Objectivities",
                table: "SubjectCards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Objectivities",
                value: "Opanowanie podstawowej wiedzy z zakresu analizy matematycznej");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Objectivities",
                table: "SubjectCards");

            migrationBuilder.AddColumn<string>(
                name: "Objectivties",
                table: "SubjectCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "Objectivties",
                value: "Opanowanie podstawowej wiedzy z zakresu analizy matematycznej");
        }
    }
}
