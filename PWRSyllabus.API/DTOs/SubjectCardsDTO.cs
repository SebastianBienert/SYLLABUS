using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabusAPI.DTOs
{
    public class SubjectCardDTO
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; }
        public string NameInPolish { get; set; }
        public string NameInEnglish { get; set; }
        //public FieldOfStudyDTO FieldOfStudy { get; set; } //out
        public string Specialization { get; set; }
        public string FormOfStudies { get; set; }
        public bool IsGroupOfCourses { get; set; }
        public string SubjectType { get; set; }
        public EmployeeDTO Supervisor { get; set; }
        public IEnumerable<CourseDTO> Courses { get; set; }
        public IEnumerable<string> Prerequisites { get; set; }
        public IEnumerable<string> Objectivities { get; set; }
        public IEnumerable<string> PrimaryLiterature { get; set; }
        public IEnumerable<string> SecondaryLiterature { get; set; }
        public IEnumerable<string> TeachingTools { get; set; } //do wyjebania?
        public IEnumerable<EducationalEffectDTO> EducationalEffects { get; set; }
        public int Version { get; set; }
        public string FinalCourseForm { get; set; }
        public Level Level { get; set; }
    }
}
