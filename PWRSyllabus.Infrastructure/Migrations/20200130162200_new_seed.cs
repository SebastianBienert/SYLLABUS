using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class new_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 2, "michal.szczepanik@smail.pwr.edu.pl", "Michał", "Szczepanik" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 3, "bogumila.hnatkowska@smail.pwr.edu.pl", "Bogumiła", "Hnatkowska" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Wydział informatyki i zarządzania" });

            migrationBuilder.InsertData(
                table: "FieldOfStudies",
                columns: new[] { "Id", "FacultyId", "Name", "Specialization" },
                values: new object[] { 2, 2, "Inzynieria Systemów", "Systemy wbudowane" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FieldOfStudies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
