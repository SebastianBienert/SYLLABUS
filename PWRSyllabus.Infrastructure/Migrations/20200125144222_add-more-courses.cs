using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class addmorecourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseForm",
                value: "Lecture");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CNPS", "CourseForm", "ECTS", "ECTSForPracticalClassees", "ECTSForTeacherStudentContact", "FormOfCrediting", "SubjectCardId", "ZZU" },
                values: new object[] { 2, 320, "Classes", 2, 1.5, 0.5, "Zaliczenie", 1, 220 });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "ClassNumber", "CourseId", "Description", "Hours" },
                values: new object[] { 2, 1, 2, "Wstęp (cel ćwiczeń). Notacja matematyczna (spójniki logiczne, kwantyfikatory), elementy teorii mnogości, liczby rzeczywiste, podzbiory zbioru liczb rzeczywistych (odcinki, półproste). Funkcje liniowe i kwadratowe", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseForm",
                value: "Lecutre");
        }
    }
}
