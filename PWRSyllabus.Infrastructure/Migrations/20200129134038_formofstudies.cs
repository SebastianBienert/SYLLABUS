using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class formofstudies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormOfStudies",
                table: "SubjectCards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfStudies",
                table: "SubjectCards");
        }
    }
}
