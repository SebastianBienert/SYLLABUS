using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class addedmissingministerialeffectattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MinisterialEffects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptiveCategory",
                table: "MinisterialEffects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MinisterialEffects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "DescriptiveCategory" },
                values: new object[] { "Wiedza: zna i rozumie", "W zaawansowanym stopniu - wybrane fakty, obiekty i zjawiska oraz dotyczące ich metody...", "Zakres i glebia - kompletnosc perspektywy poznawczej i zaleznosci" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "MinisterialEffects");

            migrationBuilder.DropColumn(
                name: "DescriptiveCategory",
                table: "MinisterialEffects");

            migrationBuilder.UpdateData(
                table: "MinisterialEffects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Zakres i glebia - kompletnosc perspektywy poznawczej i zaleznosci");
        }
    }
}
