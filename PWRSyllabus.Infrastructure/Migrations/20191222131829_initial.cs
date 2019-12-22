using Microsoft.EntityFrameworkCore.Migrations;

namespace PWRSyllabus.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalEffects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldsOfKnowledge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsOfKnowledge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameInPolish = table.Column<string>(nullable: true),
                    NameInEnglish = table.Column<string>(nullable: true),
                    SubjectCode = table.Column<string>(nullable: true),
                    IsGroupOfCourses = table.Column<bool>(nullable: false),
                    Prerequisites = table.Column<string>(nullable: true),
                    Objectivties = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    SubjectType = table.Column<string>(nullable: false),
                    SupervisorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectCards_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfStudies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOfStudies_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FieldOfKnowledgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_FieldsOfKnowledge_FieldOfKnowledgeId",
                        column: x => x.FieldOfKnowledgeId,
                        principalTable: "FieldsOfKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinisterialEffects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Profile = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: false),
                    FieldOfKnowledgeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterialEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinisterialEffects_FieldsOfKnowledge_FieldOfKnowledgeId",
                        column: x => x.FieldOfKnowledgeId,
                        principalTable: "FieldsOfKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseForm = table.Column<string>(nullable: false),
                    ECTS = table.Column<int>(nullable: false),
                    ECTSForPracticalClassees = table.Column<double>(nullable: false),
                    ECTSForTeacherStudentContact = table.Column<double>(nullable: false),
                    ZZU = table.Column<int>(nullable: false),
                    CNPS = table.Column<int>(nullable: false),
                    FormOfCrediting = table.Column<string>(nullable: true),
                    SubjectCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_SubjectCards_SubjectCardId",
                        column: x => x.SubjectCardId,
                        principalTable: "SubjectCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalEffectSubjectCards",
                columns: table => new
                {
                    EducationalEffectId = table.Column<int>(nullable: false),
                    SubjectCardId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalEffectSubjectCards", x => new { x.EducationalEffectId, x.SubjectCardId });
                    table.ForeignKey(
                        name: "FK_EducationalEffectSubjectCards_EducationalEffects_EducationalEffectId",
                        column: x => x.EducationalEffectId,
                        principalTable: "EducationalEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationalEffectSubjectCards_SubjectCards_SubjectCardId",
                        column: x => x.SubjectCardId,
                        principalTable: "SubjectCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    FormOfStudies = table.Column<string>(nullable: false),
                    Profile = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: false),
                    LanguageOfStudy = table.Column<string>(nullable: true),
                    FieldOfStudyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPrograms_FieldOfStudies_FieldOfStudyId",
                        column: x => x.FieldOfStudyId,
                        principalTable: "FieldOfStudies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldOfStudyDisciplines",
                columns: table => new
                {
                    FieldOfStudyId = table.Column<int>(nullable: false),
                    DisciplineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOfStudyDisciplines", x => new { x.FieldOfStudyId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_FieldOfStudyDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldOfStudyDisciplines_FieldOfStudies_FieldOfStudyId",
                        column: x => x.FieldOfStudyId,
                        principalTable: "FieldOfStudies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinisterialEffectEducationalEffects",
                columns: table => new
                {
                    MinisterialEffectId = table.Column<int>(nullable: false),
                    EducationalEffectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinisterialEffectEducationalEffects", x => new { x.MinisterialEffectId, x.EducationalEffectId });
                    table.ForeignKey(
                        name: "FK_MinisterialEffectEducationalEffects_EducationalEffects_EducationalEffectId",
                        column: x => x.EducationalEffectId,
                        principalTable: "EducationalEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinisterialEffectEducationalEffects_MinisterialEffects_MinisterialEffectId",
                        column: x => x.MinisterialEffectId,
                        principalTable: "MinisterialEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNumber = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyProgramId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgramSubjectCards",
                columns: table => new
                {
                    StudyProgramId = table.Column<int>(nullable: false),
                    SubjectCardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgramSubjectCards", x => new { x.StudyProgramId, x.SubjectCardId });
                    table.ForeignKey(
                        name: "FK_StudyProgramSubjectCards_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyProgramSubjectCards_SubjectCards_SubjectCardId",
                        column: x => x.SubjectCardId,
                        principalTable: "SubjectCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlanSubjectCard",
                columns: table => new
                {
                    StudyPlanId = table.Column<int>(nullable: false),
                    SubjectCardId = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlanSubjectCard", x => new { x.StudyPlanId, x.SubjectCardId });
                    table.ForeignKey(
                        name: "FK_StudyPlanSubjectCard_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyPlanSubjectCard_SubjectCards_SubjectCardId",
                        column: x => x.SubjectCardId,
                        principalTable: "SubjectCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EducationalEffects",
                columns: new[] { "Id", "Code", "Level", "Profile" },
                values: new object[] { 1, "PEK_W1", "St1Inzynier", "Practical" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 1, "pietraszko.jerzy@smail.pwr.edu.pl", "Jerzy", "Pietraszko" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Wydział elektroniki" });

            migrationBuilder.InsertData(
                table: "FieldsOfKnowledge",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Nauki matematyczne" });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "FieldOfKnowledgeId", "Name" },
                values: new object[] { 1, 1, "Matematyka" });

            migrationBuilder.InsertData(
                table: "FieldOfStudies",
                columns: new[] { "Id", "FacultyId", "Name", "Specialization" },
                values: new object[] { 1, 1, "Informatyka", "Inżynieria systemow i siecki komputerowych" });

            migrationBuilder.InsertData(
                table: "MinisterialEffects",
                columns: new[] { "Id", "Code", "Description", "FieldOfKnowledgeId", "Level", "Profile" },
                values: new object[] { 1, "P6WG", "Zakres i glebia - kompletnosc perspektywy poznawczej i zaleznosci", 1, "St1Inzynier", "Practical" });

            migrationBuilder.InsertData(
                table: "SubjectCards",
                columns: new[] { "Id", "IsGroupOfCourses", "NameInEnglish", "NameInPolish", "Objectivties", "Prerequisites", "SubjectCode", "SubjectType", "SupervisorId", "Version" },
                values: new object[] { 1, true, "Calculus", "Analiza matematyczna", "OBJ1|OBJ2", "PRE1|PRE2", "AM123", "UniversityWide", 1, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CNPS", "CourseForm", "ECTS", "ECTSForPracticalClassees", "ECTSForTeacherStudentContact", "FormOfCrediting", "SubjectCardId", "ZZU" },
                values: new object[] { 1, 400, "Lecutre", 3, 0.0, 3.0, "Egzamin", 1, 220 });

            migrationBuilder.InsertData(
                table: "EducationalEffectSubjectCards",
                columns: new[] { "EducationalEffectId", "SubjectCardId", "Code", "Description" },
                values: new object[] { 1, 1, null, null });

            migrationBuilder.InsertData(
                table: "FieldOfStudyDisciplines",
                columns: new[] { "FieldOfStudyId", "DisciplineId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MinisterialEffectEducationalEffects",
                columns: new[] { "MinisterialEffectId", "EducationalEffectId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudyPrograms",
                columns: new[] { "Id", "Description", "FieldOfStudyId", "FormOfStudies", "LanguageOfStudy", "Level", "Profile" },
                values: new object[] { 1, "Program studiow w4 inf isk", 1, "FullTime", "PL", "St1Inzynier", "Practical" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "ClassNumber", "CourseId", "Description", "Hours" },
                values: new object[] { 1, 1, 1, "Wstęp (cel wykładu). Notacja matematyczna (spójniki logiczne, kwantyfikatory), elementy teorii mnogości, liczby rzeczywiste, podzbiory zbioru liczb rzeczywistych (odcinki, półproste). Funkcje liniowe i kwadratowe", 2 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "Level", "StudyProgramId" },
                values: new object[] { 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "StudyProgramSubjectCards",
                columns: new[] { "StudyProgramId", "SubjectCardId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudyPlanSubjectCard",
                columns: new[] { "StudyPlanId", "SubjectCardId", "Semester" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectCardId",
                table: "Courses",
                column: "SubjectCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_FieldOfKnowledgeId",
                table: "Disciplines",
                column: "FieldOfKnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalEffectSubjectCards_SubjectCardId",
                table: "EducationalEffectSubjectCards",
                column: "SubjectCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfStudies_FacultyId",
                table: "FieldOfStudies",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOfStudyDisciplines_DisciplineId",
                table: "FieldOfStudyDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterialEffectEducationalEffects_EducationalEffectId",
                table: "MinisterialEffectEducationalEffects",
                column: "EducationalEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_MinisterialEffects_FieldOfKnowledgeId",
                table: "MinisterialEffects",
                column: "FieldOfKnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_StudyProgramId",
                table: "StudyPlans",
                column: "StudyProgramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlanSubjectCard_SubjectCardId",
                table: "StudyPlanSubjectCard",
                column: "SubjectCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPrograms_FieldOfStudyId",
                table: "StudyPrograms",
                column: "FieldOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgramSubjectCards_SubjectCardId",
                table: "StudyProgramSubjectCards",
                column: "SubjectCardId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectCards_SupervisorId",
                table: "SubjectCards",
                column: "SupervisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "EducationalEffectSubjectCards");

            migrationBuilder.DropTable(
                name: "FieldOfStudyDisciplines");

            migrationBuilder.DropTable(
                name: "MinisterialEffectEducationalEffects");

            migrationBuilder.DropTable(
                name: "StudyPlanSubjectCard");

            migrationBuilder.DropTable(
                name: "StudyProgramSubjectCards");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "EducationalEffects");

            migrationBuilder.DropTable(
                name: "MinisterialEffects");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "SubjectCards");

            migrationBuilder.DropTable(
                name: "FieldsOfKnowledge");

            migrationBuilder.DropTable(
                name: "StudyPrograms");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FieldOfStudies");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
