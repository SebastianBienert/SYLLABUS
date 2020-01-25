using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class addedeffects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalCourseForm",
                table: "SubjectCards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EducationalEffectSubjectCards",
                keyColumns: new[] { "EducationalEffectId", "SubjectCardId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Code", "Description" },
                values: new object[] { "PEK_W1", "Posiada podstawową wiedzę z analizy matematycznej potrzebną do rozwiązywania praktycznych problemów inżynierskich" });

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FinalCourseForm", "Objectivties", "Prerequisites" },
                values: new object[] { 0, "Opanowanie podstawowej wiedzy z zakresu analizy matematycznej", "Znajomość pojęcia funkcji i podstawowych typów funkcji elementarnych.|Umiejętność sprawnego przekształcana wyrażeń algebraicznych." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalCourseForm",
                table: "SubjectCards");

            migrationBuilder.UpdateData(
                table: "EducationalEffectSubjectCards",
                keyColumns: new[] { "EducationalEffectId", "SubjectCardId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Code", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Objectivties", "Prerequisites" },
                values: new object[] { "OBJ1|OBJ2", "PRE1|PRE2" });
        }
    }
}
