using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public static class SeedExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Jerzy",
                    LastName = "Pietraszko",
                    EmailAddress = "pietraszko.jerzy@smail.pwr.edu.pl"
                }
            );

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty
                {
                    Id = 1,
                    Name = "Wydział elektroniki",
                }
            );

            modelBuilder.Entity<FieldOfStudy>().HasData(
                new FieldOfStudy {
                    Id = 1,
                    FacultyId = 1,
                    Name = "Informatyka",
                    Specialization = "Inżynieria systemow i siecki komputerowych",
                }
            );

            modelBuilder.Entity<StudyProgram>().HasData(
                new StudyProgram
                {
                    Id = 1,
                    Description = "Program studiow w4 inf isk",
                    FormOfStudies = FormOfStudies.FullTime,
                    Profile = Profile.Practical,
                    LanguageOfStudy = "PL",
                    Level = Level.St1Inzynier,
                    FieldOfStudyId = 1
                }
            );

            modelBuilder.Entity<StudyPlan>().HasData(
                new StudyPlan
                {
                    Id = 1,
                    StudyProgramId = 1
                }
            );

            modelBuilder.Entity<SubjectCard>().HasData(
                new SubjectCard
                {
                    Id = 1,
                    Version = 1,
                    SupervisorId = 1,
                    NameInPolish = "Analiza matematyczna",
                    SubjectType = SubjectType.UniversityWide,
                    SubjectCode = "AM123",
                    Prerequisites = "PRE1|PRE2",
                    Objectivties = "OBJ1|OBJ2",
                    IsGroupOfCourses = true,
                    NameInEnglish = "Calculus"
                }
            );

            modelBuilder.Entity<StudyPlanSubjectCard>().HasData(
                new StudyPlanSubjectCard
                {
                    StudyPlanId = 1,
                    SubjectCardId = 1,
                    Semester = 1
                }
            );


            modelBuilder.Entity<StudyProgramSubjectCard>().HasData(
                new StudyProgramSubjectCard
                {
                    StudyProgramId = 1,
                    SubjectCardId = 1,
                }
            );


            modelBuilder.Entity<EducationalEffect>().HasData(
                new EducationalEffect
                {
                    Id = 1,
                    Code = "PEK_W1",
                    Level = Level.St1Inzynier,
                    Profile = Profile.Practical
                }
            );

            modelBuilder.Entity<FieldOfKnowledge>().HasData(
                new FieldOfKnowledge
                {
                    Id = 1,
                    Name = "Nauki matematyczne"
                }
            );

            modelBuilder.Entity<MinisterialEffect>().HasData(
                new MinisterialEffect
                {
                    Id = 1,
                    Code = "P6WG",
                    Description = "Zakres i glebia - kompletnosc perspektywy poznawczej i zaleznosci",
                    FieldOfKnowledgeId = 1,
                    Level = Level.St1Inzynier,
                    Profile = Profile.Practical,
                }
            );

            modelBuilder.Entity<MinisterialEffectEducationalEffect>().HasData(
                new MinisterialEffectEducationalEffect
                {
                    MinisterialEffectId = 1,
                    EducationalEffectId = 1
                }
            );

            modelBuilder.Entity<EducationalEffectSubjectCard>().HasData(
                new EducationalEffectSubjectCard
                {
                    EducationalEffectId = 1,
                    SubjectCardId = 1
                }
            );

            modelBuilder.Entity<Discipline>().HasData(
                new Discipline
                {
                    Id = 1,
                    FieldOfKnowledgeId = 1,
                    Name = "Matematyka"
                }
            );

            modelBuilder.Entity<FieldOfStudyDiscipline>().HasData(
                new FieldOfStudyDiscipline
                {
                    FieldOfStudyId = 1,
                    DisciplineId = 1
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    CNPS = 400,
                    CourseForm = CourseForm.Lecutre,
                    ECTS = 3,
                    ECTSForPracticalClassees = 0,
                    ECTSForTeacherStudentContact = 3,
                    SubjectCardId = 1,
                    ZZU = 220,
                    FormOfCrediting = "Egzamin"
                }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class
                {
                    Id = 1,
                    ClassNumber = 1,
                    CourseId = 1,
                    Hours = 2,
                    Description = "Wstęp (cel wykładu). Notacja matematyczna (spójniki logiczne, kwantyfikatory)," +
                                  " elementy teorii mnogości, liczby rzeczywiste," +
                                  " podzbiory zbioru liczb rzeczywistych (odcinki, półproste)." +
                                  " Funkcje liniowe i kwadratowe"

                }
            );


        }
    }
}
