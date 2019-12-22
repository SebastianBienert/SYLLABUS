using System.Collections.Generic;
using PWRSyllabus.Core.Enums;

namespace PWRSyllabus.Core.Entities
{
    public class Course : BaseEntity
    {
        public CourseForm CourseForm { get; set; }
        public int ECTS { get; set; }
        public double ECTSForPracticalClassees { get; set; }
        public double ECTSForTeacherStudentContact { get; set; }
        public int ZZU { get; set; }
        public int CNPS { get; set; }
        public string FormOfCrediting { get; set; }
        public SubjectCard SubjectCard { get; set; }
        public int SubjectCardId { get; set; }

        public List<Class> Classes { get; set; }
    }
}
