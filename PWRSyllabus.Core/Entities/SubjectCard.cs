using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class SubjectCard : BaseEntity
    {
        public string NameInPolish { get; set; }
        public string NameInEnglish { get; set; }
        public string SubjectCode { get; set; }
        public bool IsGroupOfCourses { get; set; }
        public string Prerequisites { get; set; }
        public string Objectivities { get; set; }
        public string PrimaryLiterature { get; set; }
        public string SecondaryLiterature { get; set; }
        public string TeachingTools { get; set; }
        public int Version { get; set; }
        public SubjectType SubjectType { get; set; }
        public CourseForm? FinalCourseForm { get; set; }
        public Employee Supervisor { get; set; }
        public int SupervisorId { get; set; }
        public List<StudyPlanSubjectCard> StudyPlanSubjectCards { get; set; }
        public List<StudyProgramSubjectCard> StudyProgramSubjectCards { get; set; }
        public List<EducationalEffectSubjectCard> EducationalEffectSubjectCards { get; set; }
        public List<Course> Courses { get; set; }
        public FormOfStudies FormOfStudies { get; set; }
    }
}
