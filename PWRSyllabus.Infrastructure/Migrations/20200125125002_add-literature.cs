using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class addliterature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimaryLiterature",
                table: "SubjectCards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryLiterature",
                table: "SubjectCards",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SubjectCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PrimaryLiterature", "SecondaryLiterature" },
                values: new object[] { "James Stewart, Essential Calculus: Early Transcendentals, 2018|Silvanus P. Thompson, Calculus Made Easy, 1998", "Adrian Banner, The Calculus Lifesaver: All the Tools You Need to Excel at Calculus, 2007" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryLiterature",
                table: "SubjectCards");

            migrationBuilder.DropColumn(
                name: "SecondaryLiterature",
                table: "SubjectCards");
        }
    }
}
