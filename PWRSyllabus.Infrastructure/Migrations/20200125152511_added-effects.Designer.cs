﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWRSyllabus.Infrastructure.EntityFramework;

namespace PWRSyllabus.Infrastructure.Migrations
{
    [DbContext(typeof(PWRSyllabusContext))]
    [Migration("20200125152511_added-effects")]
    partial class addedeffects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassNumber")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassNumber = 1,
                            CourseId = 1,
                            Description = "Wstęp (cel wykładu). Notacja matematyczna (spójniki logiczne, kwantyfikatory), elementy teorii mnogości, liczby rzeczywiste, podzbiory zbioru liczb rzeczywistych (odcinki, półproste). Funkcje liniowe i kwadratowe",
                            Hours = 2
                        },
                        new
                        {
                            Id = 2,
                            ClassNumber = 1,
                            CourseId = 2,
                            Description = "Wstęp (cel ćwiczeń). Notacja matematyczna (spójniki logiczne, kwantyfikatory), elementy teorii mnogości, liczby rzeczywiste, podzbiory zbioru liczb rzeczywistych (odcinki, półproste). Funkcje liniowe i kwadratowe",
                            Hours = 2
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CNPS")
                        .HasColumnType("int");

                    b.Property<string>("CourseForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ECTS")
                        .HasColumnType("int");

                    b.Property<double>("ECTSForPracticalClassees")
                        .HasColumnType("float");

                    b.Property<double>("ECTSForTeacherStudentContact")
                        .HasColumnType("float");

                    b.Property<string>("FormOfCrediting")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectCardId")
                        .HasColumnType("int");

                    b.Property<int>("ZZU")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectCardId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CNPS = 400,
                            CourseForm = "Lecture",
                            ECTS = 3,
                            ECTSForPracticalClassees = 0.0,
                            ECTSForTeacherStudentContact = 3.0,
                            FormOfCrediting = "Egzamin",
                            SubjectCardId = 1,
                            ZZU = 220
                        },
                        new
                        {
                            Id = 2,
                            CNPS = 320,
                            CourseForm = "Classes",
                            ECTS = 2,
                            ECTSForPracticalClassees = 1.5,
                            ECTSForTeacherStudentContact = 0.5,
                            FormOfCrediting = "Zaliczenie",
                            SubjectCardId = 1,
                            ZZU = 220
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldOfKnowledgeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfKnowledgeId");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FieldOfKnowledgeId = 1,
                            Name = "Matematyka"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.EducationalEffect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalEffects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PEK_W1",
                            Level = "St1Inzynier",
                            Profile = "Practical"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.EducationalEffectSubjectCard", b =>
                {
                    b.Property<int>("EducationalEffectId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectCardId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationalEffectId", "SubjectCardId");

                    b.HasIndex("SubjectCardId");

                    b.ToTable("EducationalEffectSubjectCards");

                    b.HasData(
                        new
                        {
                            EducationalEffectId = 1,
                            SubjectCardId = 1,
                            Code = "PEK_W1",
                            Description = "Posiada podstawową wiedzę z analizy matematycznej potrzebną do rozwiązywania praktycznych problemów inżynierskich"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "pietraszko.jerzy@smail.pwr.edu.pl",
                            FirstName = "Jerzy",
                            LastName = "Pietraszko"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Wydział elektroniki"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.FieldOfKnowledge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FieldsOfKnowledge");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nauki matematyczne"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.FieldOfStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("FieldOfStudies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FacultyId = 1,
                            Name = "Informatyka",
                            Specialization = "Inżynieria systemow i siecki komputerowych"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.FieldOfStudyDiscipline", b =>
                {
                    b.Property<int>("FieldOfStudyId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.HasKey("FieldOfStudyId", "DisciplineId");

                    b.HasIndex("DisciplineId");

                    b.ToTable("FieldOfStudyDisciplines");

                    b.HasData(
                        new
                        {
                            FieldOfStudyId = 1,
                            DisciplineId = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.MinisterialEffect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptiveCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldOfKnowledgeId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfKnowledgeId");

                    b.ToTable("MinisterialEffects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Wiedza: zna i rozumie",
                            Code = "P6WG",
                            Description = "W zaawansowanym stopniu - wybrane fakty, obiekty i zjawiska oraz dotyczące ich metody...",
                            DescriptiveCategory = "Zakres i glebia - kompletnosc perspektywy poznawczej i zaleznosci",
                            FieldOfKnowledgeId = 1,
                            Level = "St1Inzynier",
                            Profile = "Practical"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.MinisterialEffectEducationalEffect", b =>
                {
                    b.Property<int>("MinisterialEffectId")
                        .HasColumnType("int");

                    b.Property<int>("EducationalEffectId")
                        .HasColumnType("int");

                    b.HasKey("MinisterialEffectId", "EducationalEffectId");

                    b.HasIndex("EducationalEffectId");

                    b.ToTable("MinisterialEffectEducationalEffects");

                    b.HasData(
                        new
                        {
                            MinisterialEffectId = 1,
                            EducationalEffectId = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("StudyProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudyProgramId")
                        .IsUnique();

                    b.ToTable("StudyPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Level = 0,
                            StudyProgramId = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyPlanSubjectCard", b =>
                {
                    b.Property<int>("StudyPlanId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectCardId")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("StudyPlanId", "SubjectCardId");

                    b.HasIndex("SubjectCardId");

                    b.ToTable("StudyPlanSubjectCard");

                    b.HasData(
                        new
                        {
                            StudyPlanId = 1,
                            SubjectCardId = 1,
                            Semester = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldOfStudyId")
                        .HasColumnType("int");

                    b.Property<string>("FormOfStudies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageOfStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfStudyId");

                    b.ToTable("StudyPrograms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Program studiow w4 inf isk",
                            FieldOfStudyId = 1,
                            FormOfStudies = "FullTime",
                            LanguageOfStudy = "PL",
                            Level = "St1Inzynier",
                            Profile = "Practical"
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyProgramSubjectCard", b =>
                {
                    b.Property<int>("StudyProgramId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectCardId")
                        .HasColumnType("int");

                    b.HasKey("StudyProgramId", "SubjectCardId");

                    b.HasIndex("SubjectCardId");

                    b.ToTable("StudyProgramSubjectCards");

                    b.HasData(
                        new
                        {
                            StudyProgramId = 1,
                            SubjectCardId = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.SubjectCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FinalCourseForm")
                        .HasColumnType("int");

                    b.Property<bool>("IsGroupOfCourses")
                        .HasColumnType("bit");

                    b.Property<string>("NameInEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameInPolish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objectivties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prerequisites")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryLiterature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryLiterature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorId");

                    b.ToTable("SubjectCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FinalCourseForm = 0,
                            IsGroupOfCourses = true,
                            NameInEnglish = "Calculus",
                            NameInPolish = "Analiza matematyczna",
                            Objectivties = "Opanowanie podstawowej wiedzy z zakresu analizy matematycznej",
                            Prerequisites = "Znajomość pojęcia funkcji i podstawowych typów funkcji elementarnych.|Umiejętność sprawnego przekształcana wyrażeń algebraicznych.",
                            PrimaryLiterature = "James Stewart, Essential Calculus: Early Transcendentals, 2018|Silvanus P. Thompson, Calculus Made Easy, 1998",
                            SecondaryLiterature = "Adrian Banner, The Calculus Lifesaver: All the Tools You Need to Excel at Calculus, 2007",
                            SubjectCode = "AM123",
                            SubjectType = "UniversityWide",
                            SupervisorId = 1,
                            Version = 1
                        });
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Class", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Course", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.SubjectCard", "SubjectCard")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.Discipline", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.FieldOfKnowledge", "FieldOfKnowledge")
                        .WithMany("Disciplines")
                        .HasForeignKey("FieldOfKnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.EducationalEffectSubjectCard", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.EducationalEffect", "EducationalEffect")
                        .WithMany("EducationalEffectSubjectCards")
                        .HasForeignKey("EducationalEffectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWRSyllabus.Core.Entities.SubjectCard", "SubjectCard")
                        .WithMany("EducationalEffectSubjectCards")
                        .HasForeignKey("SubjectCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.FieldOfStudy", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.Faculty", "Faculty")
                        .WithMany("FieldOfStudies")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.FieldOfStudyDiscipline", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.Discipline", "Discipline")
                        .WithMany("FieldOfStudyDisciplines")
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWRSyllabus.Core.Entities.FieldOfStudy", "FieldOfStudy")
                        .WithMany("FieldOfStudyDisciplines")
                        .HasForeignKey("FieldOfStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.MinisterialEffect", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.FieldOfKnowledge", "FieldOfKnowledge")
                        .WithMany("MinisterialEffects")
                        .HasForeignKey("FieldOfKnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.MinisterialEffectEducationalEffect", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.EducationalEffect", "EducationalEffect")
                        .WithMany("MinisterialEffectEducationalEffects")
                        .HasForeignKey("EducationalEffectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWRSyllabus.Core.Entities.MinisterialEffect", "MinisterialEffect")
                        .WithMany("MinisterialEffectEducationalEffects")
                        .HasForeignKey("MinisterialEffectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyPlan", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.StudyProgram", "StudyProgram")
                        .WithOne("StudyPlan")
                        .HasForeignKey("PWRSyllabus.Core.Entities.StudyPlan", "StudyProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyPlanSubjectCard", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.StudyPlan", "StudyPlan")
                        .WithMany("StudyPlanSubjectCards")
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWRSyllabus.Core.Entities.SubjectCard", "SubjectCard")
                        .WithMany("StudyPlanSubjectCards")
                        .HasForeignKey("SubjectCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyProgram", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.FieldOfStudy", "FieldOfStudy")
                        .WithMany("StudyPrograms")
                        .HasForeignKey("FieldOfStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.StudyProgramSubjectCard", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.StudyProgram", "StudyProgram")
                        .WithMany("StudyProgramSubjectCards")
                        .HasForeignKey("StudyProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PWRSyllabus.Core.Entities.SubjectCard", "SubjectCard")
                        .WithMany("StudyProgramSubjectCards")
                        .HasForeignKey("SubjectCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWRSyllabus.Core.Entities.SubjectCard", b =>
                {
                    b.HasOne("PWRSyllabus.Core.Entities.Employee", "Supervisor")
                        .WithMany("Subjects")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
