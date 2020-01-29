using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWRSyllabus.Core.Entities;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Infrastructure.EntityFramework
{
    public class PWRSyllabusContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<EducationalEffect> EducationalEffects { get; set; }
        public DbSet<EducationalEffectSubjectCard> EducationalEffectSubjectCards { get; set; }
        public DbSet<FieldOfKnowledge> FieldsOfKnowledge { get; set; }
        public DbSet<FieldOfStudy> FieldOfStudies { get; set; }
        public DbSet<FieldOfStudyDiscipline> FieldOfStudyDisciplines { get; set; }
        public DbSet<MinisterialEffect> MinisterialEffects { get; set; }
        public DbSet<MinisterialEffectEducationalEffect> MinisterialEffectEducationalEffects { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyProgram> StudyPrograms { get; set; }
        public DbSet<StudyProgramSubjectCard> StudyProgramSubjectCards { get; set; }
        public DbSet<SubjectCard> SubjectCards { get; set; }

        public PWRSyllabusContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var profileToStringConverter = new EnumToStringConverter<Profile>();
            var levelToStringConverter = new EnumToStringConverter<Level>();
            var courseFormToStringConverter = new EnumToStringConverter<CourseForm>();
            var formOfStudiesToStringConverter = new EnumToStringConverter<FormOfStudies>();
            var subjectTypeToStringConverter = new EnumToStringConverter<SubjectType>();

            modelBuilder.Entity<FieldOfStudyDiscipline>().HasKey(x => new {x.FieldOfStudyId, x.DisciplineId});
            modelBuilder.Entity<FieldOfStudyDiscipline>()
                .HasOne(fosd => fosd.FieldOfStudy)
                .WithMany(fod => fod.FieldOfStudyDisciplines)
                .HasForeignKey(fosd => fosd.FieldOfStudyId);
            modelBuilder.Entity<FieldOfStudyDiscipline>()
                .HasOne(fosd => fosd.Discipline)
                .WithMany(fod => fod.FieldOfStudyDisciplines)
                .HasForeignKey(fosd => fosd.DisciplineId);

            modelBuilder.Entity<FieldOfStudy>()
                .HasOne(fos => fos.Faculty)
                .WithMany(f => f.FieldOfStudies)
                .HasForeignKey(fos => fos.FacultyId);


            modelBuilder.Entity<Discipline>()
                .HasOne(d => d.FieldOfKnowledge)
                .WithMany(fok => fok.Disciplines)
                .HasForeignKey(d => d.FieldOfKnowledgeId);

            modelBuilder.Entity<MinisterialEffect>()
                .HasOne(me => me.FieldOfKnowledge)
                .WithMany(fok => fok.MinisterialEffects)
                .HasForeignKey(me => me.FieldOfKnowledgeId);

            modelBuilder.Entity<MinisterialEffect>()
                .Property(me => me.Level)
                .HasConversion(levelToStringConverter);
            modelBuilder.Entity<MinisterialEffect>()
                .Property(me => me.Profile)
                .HasConversion(profileToStringConverter);

            modelBuilder.Entity<MinisterialEffectEducationalEffect>()
                .HasKey(meee => new {meee.MinisterialEffectId, meee.EducationalEffectId});

            modelBuilder.Entity<MinisterialEffectEducationalEffect>()
                .HasOne(meee => meee.MinisterialEffect)
                .WithMany(me => me.MinisterialEffectEducationalEffects)
                .HasForeignKey(meee => meee.MinisterialEffectId);

            modelBuilder.Entity<MinisterialEffectEducationalEffect>()
                .HasOne(meee => meee.EducationalEffect)
                .WithMany(ee => ee.MinisterialEffectEducationalEffects)
                .HasForeignKey(meee => meee.EducationalEffectId);



            modelBuilder.Entity<StudyProgram>()
                .Property(sp => sp.Profile)
                .HasConversion(profileToStringConverter);
            modelBuilder.Entity<StudyProgram>()
                .Property(sp => sp.Level)
                .HasConversion(levelToStringConverter);
            modelBuilder.Entity<StudyProgram>()
                .Property(sp => sp.FormOfStudies)
                .HasConversion(formOfStudiesToStringConverter);
            modelBuilder.Entity<StudyProgram>()
                .HasOne(sp => sp.FieldOfStudy)
                .WithMany(fos => fos.StudyPrograms)
                .HasForeignKey(sp => sp.FieldOfStudyId);
            modelBuilder.Entity<StudyProgram>()
                .HasOne(sp => sp.StudyPlan)
                .WithOne(sp => sp.StudyProgram)
                .HasForeignKey<StudyPlan>(sp => sp.StudyProgramId);


            modelBuilder.Entity<StudyPlanSubjectCard>().HasKey(spsc => new {spsc.StudyPlanId, spsc.SubjectCardId});

            modelBuilder.Entity<StudyPlanSubjectCard>()
                .HasOne(spsc => spsc.StudyPlan)
                .WithMany(sp => sp.StudyPlanSubjectCards)
                .HasForeignKey(spsc => spsc.StudyPlanId);

            modelBuilder.Entity<StudyPlanSubjectCard>()
                .HasOne(spsc => spsc.SubjectCard)
                .WithMany(sc => sc.StudyPlanSubjectCards)
                .HasForeignKey(spsc => spsc.SubjectCardId);


            modelBuilder.Entity<SubjectCard>()
                .Property(sc => sc.SubjectType)
                .HasConversion(subjectTypeToStringConverter);

            modelBuilder.Entity<SubjectCard>()
                .HasOne(sc => sc.Supervisor)
                .WithMany(e => e.Subjects)
                .HasForeignKey(sc => sc.SupervisorId);


            modelBuilder.Entity<StudyProgramSubjectCard>()
                .HasKey(spsc => new {spsc.StudyProgramId, spsc.SubjectCardId});

            modelBuilder.Entity<StudyProgramSubjectCard>()
                .HasOne(spsc => spsc.StudyProgram)
                .WithMany(sp => sp.StudyProgramSubjectCards)
                .HasForeignKey(spsc => spsc.StudyProgramId);

            modelBuilder.Entity<StudyProgramSubjectCard>()
                .HasOne(spsc => spsc.SubjectCard)
                .WithMany(sc => sc.StudyProgramSubjectCards)
                .HasForeignKey(spsc => spsc.SubjectCardId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.SubjectCard)
                .WithMany(sc => sc.Courses)
                .HasForeignKey(c => c.SubjectCardId);

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseForm)
                .HasConversion(courseFormToStringConverter);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany(c => c.Classes)
                .HasForeignKey(c => c.CourseId);


            modelBuilder.Entity<EducationalEffectSubjectCard>()
                .HasKey(eesc => new {eesc.EducationalEffectId, eesc.SubjectCardId});

            modelBuilder.Entity<EducationalEffectSubjectCard>()
                .HasOne(eesc => eesc.EducationalEffect)
                .WithMany(ee => ee.EducationalEffectSubjectCards)
                .HasForeignKey(eesc => eesc.EducationalEffectId);

            modelBuilder.Entity<EducationalEffectSubjectCard>()
                .HasOne(eesc => eesc.SubjectCard)
                .WithMany(sc => sc.EducationalEffectSubjectCards)
                .HasForeignKey(eesc => eesc.SubjectCardId);


            modelBuilder.Seed();

        }
    }
}
