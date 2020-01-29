using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class addedteachingtools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeachingTools",
                table: "SubjectCards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "TeachingTools",
                value: "Wykład tradycyjny|Konsultacjedla studentów|Praca własna –samodzielne studia i przygotowanie do egzaminu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachingTools",
                table: "SubjectCards");
        }
    }
}
